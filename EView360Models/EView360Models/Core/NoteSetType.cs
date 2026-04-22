using EView360Models.CustomValidationAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EView360Models.Core;

public partial class NoteSetType
{
    [Required(ErrorMessage = "This field is required")]
    public string NoteSetTypeName { get; set; } = null!;

    [RequiredIfOtherFieldHasValue("DenominationType1Title", ErrorMessage = "Type1 Denomination is required")]
    public int? DenominationType1 { get; set; }

    [RequiredIfOtherFieldHasValue("DenominationType2Title", ErrorMessage = "Type2 Denomination is required")]
    public int? DenominationType2 { get; set; }

    [RequiredIfOtherFieldHasValue("DenominationType3Title", ErrorMessage = "Type3 Denomination is required")]
    public int? DenominationType3 { get; set; }

    [RequiredIfOtherFieldHasValue("DenominationType4Title", ErrorMessage = "Type4 Denomination is required")]
    public int? DenominationType4 { get; set; }

    [RequiredIfOtherFieldHasValue("DenominationType5Title", ErrorMessage = "Type5 Denomination is required")]
    public int? DenominationType5 { get; set; }

    [RequiredIfOtherFieldHasValue("DenominationType6Title", ErrorMessage = "Type6 Denomination is required")]
    public int? DenominationType6 { get; set; }

    [RequiredIfOtherFieldHasValue("DenominationType7Title", ErrorMessage = "Type7 Denomination is required")]
    public int? DenominationType7 { get; set; }

    public long NoteSetTypeId { get; set; }

    public long CreatedBy { get; set; }

    [NotMapped]
    public string? CreatedByName { get; set; }

    [RequiredIfOtherFieldHasValue("DenominationType1", ErrorMessage = "Type1 Title is required")]
    [AtLeastOneRequired("DenominationType1Title,DenominationType2Title,DenominationType3Title,DenominationType4Title,DenominationType5Title,DenominationType6Title,DenominationType7Title", ErrorMessage = "Atleast 1 DenominationType is required")]
    public string? DenominationType1Title { get; set; }

    [RequiredIfOtherFieldHasValue("DenominationType2", ErrorMessage = "Type2 Title is required")]
    public string? DenominationType2Title { get; set; }

    [RequiredIfOtherFieldHasValue("DenominationType3", ErrorMessage = "Type3 Title is required")]
    public string? DenominationType3Title { get; set; }

    [RequiredIfOtherFieldHasValue("DenominationType4", ErrorMessage = "Type4 Title is required")]
    public string? DenominationType4Title { get; set; }

    [RequiredIfOtherFieldHasValue("DenominationType5", ErrorMessage = "Type5 Title is required")]
    public string? DenominationType5Title { get; set; }

    [RequiredIfOtherFieldHasValue("DenominationType6", ErrorMessage = "Type6 Title is required")]
    public string? DenominationType6Title { get; set; }

    [RequiredIfOtherFieldHasValue("DenominationType7", ErrorMessage = "Type7 Title is required")]
    public string? DenominationType7Title { get; set; }

    public DateTime CreationTime { get; set; }

    public bool? IsType1MultiCurrency { get; set; }

    public bool? IsType2MultiCurrency { get; set; }

    public bool? IsType3MultiCurrency { get; set; }

    public bool? IsType4MultiCurrency { get; set; }

    public bool? IsType5MultiCurrency { get; set; }

    public bool? IsType6MultiCurrency { get; set; }

    public bool? IsType7MultiCurrency { get; set; }

    public bool? IsType1Recycler { get; set; }

    public bool? IsType2Recycler { get; set; }

    public bool? IsType3Recycler { get; set; }

    public bool? IsType4Recycler { get; set; }

    public bool? IsType5Recycler { get; set; }

    public bool? IsType6Recycler { get; set; }

    public bool? IsType7Recycler { get; set; }

    public bool? IsEdited { get; set; }
}
