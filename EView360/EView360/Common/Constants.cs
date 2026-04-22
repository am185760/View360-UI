namespace EView360.Common
{
    public class Constants
    {
        public struct SessionStorageKeys
        {
            public const string AtmList = "AtmList";
            public const string RegionList = "RegionList";
            public const string SelectedRegionId = "SelectedRegionId";
            public const string SelectedRegionIdWithAllChildRegions = "SelectedRegionIdWithAllChildRegions";
            public const string SelectedtAtmId = "SelectedtAtmId";
            public const string SelectedtAtmParentId = "SelectedtAtmParentId";
            public const string SelectedType = "SelectedType";
            public const string TypeAtm = "Atm";
            public const string TypeRegion = "Region";
        }

        public struct Messages
        {
            public const string AtmSelectionMsg = "Please select atm from left tree.";
            public const string AtmSingleSelectionMsg = "Please select only 1 atm from left tree.";
            public const string AtmAlreadyScheduleMsg = "Selected atm/s already schedule for configuration.";
            public const string AtmAlreadyDwnldMsg = "Selected atm already schedule for download.";
            public const string AllAtmSucessMsg = "Selected atm/s schedule for configuration successfully.";
            public const string FileDwnldSucessMsg = "Selected atm schedule for download successfully.";
            public const string AllAtmSucessWithExceptMsg = "Selected atm/s schedule for configuration successfully with some exceptions.";
        }

        public struct ReportNames
        {
            public const string SimpleList = "SimpleList";
            public const string TaskStatusReport = "TaskStatusReport";
        }

        public enum RenderMessageType
        {
            Error,
            Success,
            Info
        };
    }
}
