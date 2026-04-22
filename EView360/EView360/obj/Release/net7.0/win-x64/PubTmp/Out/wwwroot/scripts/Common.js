function initializeInactivityTimer(dotnetHelper) {
    $(document).inactivity({
        // options here
    });

    $(document).on("inactivity", function () {
        dotnetHelper.invokeMethodAsync("Logout");
    });
}


function handleDashboardSpinner() {
    $(".table-row-selectable").ready(function () {
        $(".spinner_Dashboard").hide();
    });
}

function handleCollapsed() {
    //alert($(document).width());
    //alert($('#treeviewContainer').is(':visible'))
    if ($('#treeviewContainer').is(':visible') == false) {
        // alert('false.changing to 1200');
        $('#divGridAdjuster').width($(document).width() - 494);
    }
    else {
        //  alert('true.chanding to 400');
        $('#divGridAdjuster').width($(document).width() - 244);
    }
    $('#treeviewContainer').slideToggle();
}

function setFocusToUsername() {
    document.getElementById("username-textbox").focus();
} 

function setFocusToPassword() {
    document.getElementById("password-textbox").focus();
} 

function openWindowWithPost(url, data) {
    var form = document.createElement("form");
    form.target = "_blank";
    form.method = "POST";
    form.action = url;
    form.style.display = "none";

    for (var key in data) {
        var input = document.createElement("input");
        input.type = "hidden";
        input.name = key;
        input.value = data[key];
        form.appendChild(input);
    }
    document.body.appendChild(form);
    form.submit();
    document.body.removeChild(form);
}



function downloadFile(content, fileName) {
    const blob = new Blob([content], { type: "text/plain" });
    const url = URL.createObjectURL(blob);
    const link = document.createElement("a");
    link.href = url;
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    URL.revokeObjectURL(url);
}

function saveFile(dotNetHelper, filename, context) {
    var element = document.createElement('a');
    element.setAttribute('href', 'data:text/plain;charset=utf-8,' + encodeURIComponent(context));
    element.setAttribute('download', filename);

    element.style.display = 'none';
    document.body.appendChild(element);

    element.click();

    document.body.removeChild(element);
}

function atmTreeCollapsed() {
    $('.atm-Tree-container').toggle(50, function () {
        if ($('.atm-Tree-container').is(':visible')) {
            $('.other-content').removeClass("col-sm-12");
            $('.other-content').addClass("col-sm-10");
        }
        else {
            $('.other-content').removeClass("col-sm-10");
            $('.other-content').addClass("col-sm-12");
        }
    });
}


function CloseDatePicker() {
    $(".flatpickr-calendar").removeClass("open");
    $(".form-control").removeClass("active");
}

function handleDatePicker(dotNetHelper) {

    $(document).ready(function () {
        setTimeout(
            function () {
                if ($('.flatpickr-time').length > 0) {
                    $('.flatpickr-time').after('<button type="button" class="btn btn-success btn-lg btn-block" onclick="CloseDatePicker()">OK</button>');
                }
                else {
                    $('.flatpickr-days').after('<button type="button" class="btn btn-success btn-lg btn-block" onclick="CloseDatePicker()">OK</button>');
                }
            }, 300);
    });

}

function renderjQueryComponents(dotNetHelper) {


    $(document).ready(function () {
        $('#jstree').jstree('destroy');
        $('#jstree').jstree({
            "core": {
                "themes": {
                    "responsive": false
                },
                // so that create works
                "check_callback": true,
                'data': function (obj, cb) {
                    GetFirstLevelChildren(obj.id, cb);                    
                },
                'multiple': false,
            },
            "check_callback": function (op) {
                if (op === 'delete_node') {
                    return confirm('Are you sure?');
                }
            },
            "types": {
                "#": { // the root node can have only "branch" children
                    "valid_children": ["TreeRoot"]
                },
                "TreeRoot": {
                    "valid_children": ["default", "non_atm"]
                },
                "atm": {
                    "max_children": 0
                }
            },
            "plugins": ["dnd", "types", "contextmenu", "search"],
            "contextmenu": {
                "items": customMenu
            },
            "search": {
                "case_sensitive": false,
                "show_only_matches": false
            }
        });
        $(".spinner_tree").hide();

        $.when($('#jstree').show()).then(function () {
            setTimeout(
                function () {
                    $("#r1_anchor").addClass('jstree-clicked');
                }, 200);            
        });        
    });


    var tree = $("#jstree").jstree(true);
    var matches = [];
    var searchString = '';

    $(document).ready(function () {
        $(".search-input-atm").keyup(function () {
            searchString = $(this).val();
            matches = [];

            if (searchString && searchString.length > 0) {
                // Get the root node
                tree.open_all();
                var rootNode = tree.get_node('#');

                // Call the recursive function to iterate through all nodes
                iterateNodes(rootNode);

                tree.hide_all();
                if (matches.length > 0) {
                    $.each(matches, function (key, value) {
                        var parentNodeId = tree.get_parent(value);
                        while (parentNodeId !== '#') {
                            tree.show_node(parentNodeId);
                            parentNodeId = tree.get_parent(parentNodeId);
                        }
                        tree.show_node(value);
                    });
                    $.each(matches, function (key, value) {
                        $('#' + value).addClass("jstree-search");
                    });
                }
                else {
                    tree.clear_search();
                    tree.show_all();
                    tree.close_all();
                    $('#jstree').jstree('search', searchString);
                }
            }
            else {
                tree.clear_search();
                tree.show_all();
                tree.close_all();
                tree.open_node("r1");
            }
        });
    });

    function GetFirstLevelChildren(regionId, cb) {

        var jstreeNodes = '';
        dotNetHelper.invokeMethodAsync("GetFirstLevelChildren", regionId).then(response => {
            if (response.nodes?.length > 0) {
                jstreeNodes = response.nodes.map(node => ({
                    id: node.id,
                    icon: node.icon,
                    text: node.text,
                    children: Boolean(node.hasChildren),
                    type: node.type,
                    a_attr: { title: node.toolTip }
                }));
                cb.call(this, jstreeNodes);
            }
        });
    }

    function customMenu(node) {
        var items = {
            'Create': {
                'label': 'Create region',
                'action': function (obj) {
                    var parentId = node.id;
                    var nodeIcon = "fas fa-sitemap";

                    tree.create_node(node, { id: 'newNode_' + (Math.random() + 1).toString(36).substring(7), text: 'new Region', icon: nodeIcon, a_attr: { type: 'non_atm', parentId: parentId } });
                    //$('#jstree').jstree(true).select_node(node.id);
                    //alert('after create node');

                }
            },
            'Rename': {
                'label': 'Rename',
                'action': function (e, data) {
                    tree.edit(node);
                }
            },
            'Delete': {
                'label': 'Delete',
                'action': function (obj) {
                    if (node.children.length == 0) {
                        DeleteNode(node);
                    }
                    else {
                        dotNetHelper.invokeMethodAsync("RenderErrorBox", "Error !", "Cannot delete selected organization as it has one or more child objects");
                    }
                }
            }
        }
        if (node.type === 'atm') {
            delete items.Delete;
            delete items.Create;
        }

        return items;
    }

    $('#jstree').on('ready.jstree', function (e, data) {
        //$('#jstree').jstree("select_node", "r1");
        //dotNetHelper.invokeMethodAsync("NodeSelected", "r1", "r1");
        dotNetHelper.invokeMethodAsync("HandleTreeLoadingBit");
    });


    $('#jstree').on('create_node.jstree', function (e, data) {

        if (data.node.id.charAt(0) != 'a' && data.node.id.includes("newNode")) {
            $("#jstree").jstree().deselect_all(true);
            tree.edit(data.node);
        }

        //, 'null', function (node, status, is_cancel) {
        //    $("#jstree").jstree("select_node", data.node.id); 
        //    //$('#jstree').select_node(data.id);
        //    alert('should be selected:' + data.node.id);
        //    console.log(data);
        //});
        //$('#jstree').jstree(true).select_node(data);
        //alert('in create call');
    });

    //$('#jstree')
    //    .on('ready.jstree', function (e, data) {
    //        // do function after jstree initialized
    //        $('#jstree')
    //            .jstree(true)
    //            .select_node('r1');
    //        console.log('ready called');
    //    });

    //$("#jstree").on("loaded.jstree", function () {
    //    // don't use "#" for ID
    //    $('#jstree').jstree(true).select_node('r1');
    //    alert('sele');
    //});
    $('#jstree').on("rename_node.jstree", function (e, data) {
        $("#jstree").jstree().deselect_all(true);
        var currentNode = data.node;
        if (currentNode.id.includes("newNode")) {
            dotNetHelper.invokeMethodAsync("CreateRegion", currentNode.text, currentNode.a_attr.parentId).then(response => {

                if (response.toLowerCase().includes("error")) {
                    $('#jstree').jstree("refresh");
                    dotNetHelper.invokeMethodAsync("RenderErrorBox", "Error !", response);
                }
                else {
                    $('#jstree').jstree(true).set_id(currentNode, "r" + response);
                    $("#jstree").jstree("select_node", data.node.id);
                    dotNetHelper.invokeMethodAsync("RenderSuccessBox", "Success !", "Region created");
                }
            });
        }
        else {
            if (data.text != data.old) {
                var renameNode = true;
                if (currentNode.id.charAt(0) == "a") {
                    var atmIpRegex = new RegExp('[A-z][A-z][A-z][0-9][0-9][0-9][0-9][0-9]');
                    if (!atmIpRegex.test(data.text) || data.text.length != 8) {
                        renameNode = false;
                        $("#jstree").jstree('set_text', data.node, data.old);
                        tree.edit(data.node);
                        dotNetHelper.invokeMethodAsync("RenderErrorBox", "Error !", "ATM ID should contain first 3 characters followed by 5 numberic digits");
                    }
                }
                if (renameNode) {
                    dotNetHelper.invokeMethodAsync("RenameNode", currentNode.id, data.text, data.old).then(response => {
                        if (response != "success") {
                            dotNetHelper.invokeMethodAsync("RenderErrorBox", "Error !", response);
                            $("#jstree").jstree('set_text', data.node, data.old);
                            tree.edit(data.node);
                        }
                        else {
                            if (currentNode.id.charAt(0) == "a") {
                                dotNetHelper.invokeMethodAsync("RenderSuccessBox", "Success !", "Atm renamed");
                            }
                            else {
                                dotNetHelper.invokeMethodAsync("RenderSuccessBox", "Success !", "Region renamed");
                            }
                            
                        }
                    });
                }
            }
        }
    });

    function DeleteNode(node) {
        $("#jstree").jstree().deselect_all(true);
        dotNetHelper.invokeMethodAsync("DeleteNode", node.id).then(response => {

            if (response != "cancel") {
                if (response == "success") {
                    tree.delete_node(node);
                    dotNetHelper.invokeMethodAsync("RenderSuccessBox", "Success !", "Node deleted");
                }
                else {
                    dotNetHelper.invokeMethodAsync("RenderErrorBox", "Error !", response);
                }
            }
        });
    }



    $('#jstree').on("move_node.jstree", function (e, data) {
        $("#jstree").jstree().deselect_all(true);

        dotNetHelper.invokeMethodAsync("MoveNode", data.node.id, data.parent).then(response => {
            if (response != "success") {
                $('#jstree').jstree("refresh");
                dotNetHelper.invokeMethodAsync("RenderErrorBox", "Error !", response);
            }
            else {
                dotNetHelper.invokeMethodAsync("RenderSuccessBox", "Success !", "Node moved");
            }
        });
    });

    $('#jstree').on('select_node.jstree', function (e, data) {
        if (!document.hidden) {
            if (!$("#" + data.node.id + "_anchor").hasClass('jstree-search')) {
                $("#jstree").jstree(true).clear_search();
                $(".tt-input.typeahead").val('');
            }
            dotNetHelper.invokeMethodAsync("NodeSelected", data.node.id, data.node.parent);
        }              
    });

    function iterateNodes(node) {

        // Get the children of the current node
        var children = tree.get_children_dom(node);

        // Iterate through the children nodes
        children.each(function () {
            var childNode = tree.get_node(this);
            if (childNode && childNode.li_attr && childNode.li_attr.location) {
                if (childNode.li_attr.location.toLowerCase().includes(searchString.toLowerCase())) {
                    matches.push(childNode.id);
                }
            }
            iterateNodes(childNode, tree); // Call the function recursively for each child node
        });
    }
}


function initializeTypeahead(dotNetHelper, atmList) {

    var bloodHoundSuggestion = new Bloodhound({
        datumTokenizer: function (d) {
            var test = Bloodhound.tokenizers.whitespace(d);
            $.each(test, function (k, v) {
                i = 0;
                while ((i + 1) < v.length) {
                    test.push(v.substr(i, v.length));
                    i++;
                }
            })
            return test;
        },
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        local: atmList
    });
    $('#the-basics .typeahead').typeahead({
        hint: false,
        highlight: true,
        minLength: 1
    },
        {
            name: 'bloodHoundSuggestion',
            source: bloodHoundSuggestion,
            limit: 100
        });


    $(".tt-input.typeahead ").keyup(function (e) {
        if (e.which == 13) {
            if ($(".tt-input.typeahead ").val().length > 0) {
                dotNetHelper.invokeMethodAsync("AutocompleteHandler", $(".tt-input.typeahead ").val());
            }
        }
    });

    $(".tt-menu").on("click", function () {
        if ($(".tt-input.typeahead ").val().length > 0) {
            dotNetHelper.invokeMethodAsync("AutocompleteHandler", $(".tt-input.typeahead ").val());
        }
    });
}

function UpdateTypeAhead(dotNetHelper, atmList) {
    $('#the-basics .typeahead').typeahead('destroy');
    setTimeout(function () {
        initializeTypeahead(dotNetHelper, atmList);
    }, 50);
}


function ClearSearch() {
    $(".tt-input.typeahead").val('');
    var tree = $("#jstree").jstree(true);
    tree.clear_search();
    tree.close_all();
}


function AtmTreeLocationSearchHandler(atmIds, parentRegionIdsLst) {
        
    var tree = $("#jstree").jstree(true);
    ClearSearch();
    tree.deselect_all();

    $.when(
        $.each(parentRegionIdsLst, function (index, parentRegionIds) {
            var index = 0;
            var isSearchCompleted = 0;
            tree.open_node('r' + parentRegionIds[index]);

            $('#jstree').on("after_open.jstree", function (e, data) {

                if (isSearchCompleted == 0) {
                    tree.show_node('r' + parentRegionIds[index]);
                    index++;
                    if (index < parentRegionIds.length) {
                        tree.open_node('r' + parentRegionIds[index]);
                    }
                    else {
                        isSearchCompleted = 1;
                    }
                    //tree.select_node(atmIds);                    
                }
            });
        })
    ).then(function () {
        setTimeout(
            function () {
                $.each(atmIds, function (index, singleId) {
                    $('#' + singleId).addClass("jstree-search");
                });
                ScrollToDiv($("#" + atmIds[0] + "_anchor"));
            }, 1500);
    });
}

function AtmTreeSearchHandler(dotNetHelper, searchString, atmId, regionId, parentRegionIds) {

    var index = 0;
    var isSearchCompleted = 0;
    var tree = $("#jstree").jstree(true);
    ClearSearch();
    if (!tree.is_open('r' +parentRegionIds[parentRegionIds.length - 1])) {        
        tree.open_node('r' + parentRegionIds[index]);

        $('#jstree').on("after_open.jstree", function (e, data) {

            if (isSearchCompleted == 0) {
                tree.show_node('r' + parentRegionIds[index]);
                index++;
                if (index < parentRegionIds.length) {
                    tree.open_node('r' + parentRegionIds[index]);
                }
                else {
                    isSearchCompleted = 1;
                    tree.deselect_all();
                    $.when($('#jstree').jstree('search', searchString)).then(function () {                        
                        tree.select_node('a' + atmId);
                        ScrollToDiv($("#a" + atmId + "_anchor"));
                    });                    
                }
            }
        });
    }
    else {
        tree.deselect_all();
        $.when($('#jstree').jstree('search', searchString)).then(function () {            
            tree.select_node('a' + atmId);
            ScrollToDiv($("#a" + atmId + "_anchor"));
        });
    }    
}

function AtmTreeRegionSearchHandler(searchString, regionId, parentRegionIds) {

    var index = 0;
    var isSearchCompleted = 0;
    var tree = $("#jstree").jstree(true);
    ClearSearch();
    if (!tree.is_open('r' + parentRegionIds[parentRegionIds.length - 1])) {
        tree.open_node('r' + parentRegionIds[index]);

        $('#jstree').on("after_open.jstree", function (e, data) {

            if (isSearchCompleted == 0) {
                tree.show_node('r' + parentRegionIds[index]);
                index++;
                if (index < parentRegionIds.length) {
                    tree.open_node('r' + parentRegionIds[index]);
                }
                else {
                    isSearchCompleted = 1;
                    tree.deselect_all();
                    $.when($('#jstree').jstree('search', searchString)).then(function () {
                        tree.select_node('r' + regionId);
                        ScrollToDiv($("#r" + regionId + "_anchor"));
                    });
                }
            }
        });
    }
    else {
        tree.deselect_all();
        $.when($('#jstree').jstree('search', searchString)).then(function () {
            tree.select_node('r' + atmId);
            ScrollToDiv($("#r" + atmId + "_anchor"));
        });
    }
}

function ScrollToDiv(el) {
    var elOffset = el.offset().top;
    var elHeight = el.height();
    var windowHeight = $(window).height();
    var offset;

    if (elHeight < windowHeight) {
        offset = elOffset - ((windowHeight / 2) - (elHeight / 2));
    }
    else {
        offset = elOffset;
    }
    var speed = 700;
    $('.atm-Tree-container').animate({ scrollTop: offset }, speed);
}

function CreateNode(dotNetHelper, parentName, AtmId, AtmName) {

    var Atmtree = $("#jstree").jstree(true);
    var node = { id: AtmId, text: AtmName, icon: "fa fa-credit-card", type: 'atm' };

    Atmtree.create_node(parentName, node);
    var newlyCreatedAtmNode = Atmtree.get_node(AtmId);
    Atmtree.set_type('atm', newlyCreatedAtmNode);
    console.log(parentName);
    Atmtree.deselect_all();
    Atmtree.select_node(node.id);
}

function UpdateNode(dotNetHelper, parentName, AtmId, AtmName) {

    var Atmtree = $("#jstree").jstree(true);
    var node = { id: AtmId, text: AtmName, icon: "fa fa-credit-card", type: 'atm' };

    Atmtree.delete_node(AtmId);
    Atmtree.create_node(parentName, node);
    var newlyCreatedAtmNode = Atmtree.get_node(AtmId);
    Atmtree.set_type('atm', newlyCreatedAtmNode);

    const kbEvent = new KeyboardEvent('keydown', {
        bubbles: true,
        cancelable: true,
        key: 'Enter',
    });

    document.body.dispatchEvent(kbEvent);
    Atmtree.select_node(node.id);
    //$("#btn1").click();
    //$('#btnHidden').click();
    //, "first", function (node) {
    //    console.log('region name:' + parentName);
    //});

    //    setTimeout(function () {
    //        $('#jstree').jstree(true).select_node(parentName);
    //}, 500);



    //$('#jstree').jstree(true).refresh();

    //$('#jstree').jstree(true).select_node(parentName);
    console.log('update node called ');
    //    $('jstree').jstree("refresh");
}


function DeleteNode(dotNetHelper, AtmId) {
    $('#jstree').jstree(true).delete_node(AtmId);
}

function SelectNode(dotNetHelper, AtmId) {
    $('#jstree').jstree("select_node", AtmId);
}

function DeselectAll(dotNetHelper) {
    $('#jstree').jstree().deselect_all(true);
}

function renderComponents(dotNetHelper, atmsLists) {
    $("#CheckboxJstree").jstree("destroy");
    $('#CheckboxJstree').jstree({
        "plugins": ["types", "search", "checkbox"],
        "search": {
            "case_sensitive": false,
            "show_only_matches": true
        }
    });

    var tree = $("#CheckboxJstree").jstree(true);

    $(document).ready(function () {
        $(".search-input-atm").keyup(function () {
            searchString = $(this).val();
            matches = [];

            if (searchString && searchString.length > 0) {
                // Get the root node
                tree.open_all();
                var rootNode = tree.get_node('#');

                // Call the recursive function to iterate through all nodes
                iterateNodes(rootNode);

                tree.hide_all();
                if (matches.length > 0) {
                    $.each(matches, function (key, value) {
                        var parentNodeId = tree.get_parent(value);
                        while (parentNodeId !== '#') {
                            tree.show_node(parentNodeId);
                            parentNodeId = tree.get_parent(parentNodeId);
                        }
                        tree.show_node(value);
                    });
                    $.each(matches, function (key, value) {
                        $('#' + value).addClass("jstree-search");
                    });
                }
                else {
                    tree.clear_search();
                    tree.show_all();
                    tree.close_all();
                    $('#CheckboxJstree').jstree('search', searchString);
                }
            }
            else {
                tree.clear_search();
                tree.show_all();
                tree.close_all();
                tree.open_node("r1");
            }
        });

        //setUserAtmAsChecked
        
        if (atmsLists!=null && atmsLists.length > 0) {
            $('#CheckboxJstree').jstree(true).check_node(atmsLists);
        }

        $(".spinner").hide();
        $('#CheckboxJstree').show();
    });

    function iterateNodes(node) {

        // Get the children of the current node
        var children = tree.get_children_dom(node);

        // Iterate through the children nodes
        children.each(function () {
            var childNode = tree.get_node(this);
            if (childNode && childNode.li_attr && childNode.li_attr.location) {
                if (childNode.li_attr.location.toLowerCase().includes(searchString.toLowerCase())) {
                    matches.push(childNode.id);
                }
            }
            iterateNodes(childNode, tree); // Call the function recursively for each child node
        });
    }
}



function getCheckboxSelection(dotNetHelper) {
    var selectedElmsIds = [];
    var selectedElms = $('#CheckboxJstree').jstree("get_selected", true);
    $.each(selectedElms, function () {
        selectedElmsIds.push(this.id);
    });
    return selectedElmsIds;
}

function setUserAtmAsChecked(dotNetHelper, atmsLists) {
    atmsLists.forEach(AtmId => {
        AtmId = 'a' + AtmId;
        $('#CheckboxJstree').jstree("check_node", AtmId);
    }
    )
    $(".spinner").hide();
    $('#CheckboxJstree').show();
}