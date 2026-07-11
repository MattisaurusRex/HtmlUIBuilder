using System.Collections.Generic;
using HtmlWinUI.Models.Details.Files;
using HtmlWinUI.Models.Entities;
using HtmlWinUI.Models.Search;

namespace HtmlWinUI.Services
{
    /// <summary>
    /// Mock data source, ported from the hardcoded results in FilesController.
    /// </summary>
    public static class SampleDataService
    {
        public static List<FileEntity> SearchFiles(FilesSearchModel _)
        {
            return new List<FileEntity>
            {
                new FileEntity()
                {
                    PK = 1,
                    InstructionText = "take File blahblahblah",
                    FileTypeId = "3",
                    Required = "false",
                    FileCollected = "0",
                    FileCollectionStatusId = "5",
                    PhotoStatusId = "3",
                    StatusReason = "",
                    FileSource = "",
                    FileColour = "",
                    FilePackId = "",
                    FileTestType = "",
                    FileLengthInCm = "",
                    FileQty = ""
                },
                new FileEntity()
                {
                    PK = 2,
                    InstructionText = "no isntruction",
                    FileTypeId = "4",
                    Required = "true",
                    FileCollected = "0",
                    FileCollectionStatusId = "3",
                    PhotoStatusId = "4",
                    StatusReason = "",
                    FileSource = "",
                    FileColour = "",
                    FilePackId = "",
                    FileTestType = "",
                    FileLengthInCm = "",
                    FileQty = ""
                }
            };
        }

        public static FileDetailHeader GetFileDetail(int fileId)
        {
            // FilesController.Details returned an empty FileDetailHeader;
            // populate the ID so the header shows which file was opened.
            return new FileDetailHeader { PK = fileId, EntityID = fileId };
        }
    }
}
