var elapsedTime = 0


function initializeInactivityTimer2(dotnetHelper) {


    window.onfocus = function () { elapsedTime = 0 }
    window.onclick = function () { elapsedTime = 0 }

    var frequency = setInterval(function () {
        elapsedTime++
        if (elapsedTime > 180) { // 180 seconds = 3 minutes timeout
            clearInterval(frequency)
            dotnetHelper.invokeMethodAsync("Logout");
        }
    }, 1000)   
}

function timerIncrement() {
    idleTime = idleTime + 1;
    if (idleTime > idleMax) {
        dotNet.invokeMethodAsync("Logout");
    }
}