public class Archiver
{

    public string PdfFilesArchiveLocation { get; set; }
    public string PdfFilesLocation { get; set; }
    
    public string TextFilesArchiveLocation { get ;set; }
    public string TextFilesLocation { get; set; }

    public bool TryBoth { get; set; }



    public void ArchivePdfFilesToArchiveLocation()
    {
        var pdfFiles = System.IO.Directory.GetFiles(PdfFilesLocation);

        foreach(var pdfFile in pdfFiles)
        {
            var index = pdfFile.LastIndexOf("\\");
            var pdfFileName = pdfFile.Substring(index);

            System.IO.File.Move(pdfFile,  PdfFilesArchiveLocation + pdfFileName);
        }       

        if(TryBoth == true)
        {
            var textFiles = System.IO.Directory.GetFiles(PdfFilesLocation);

            foreach(var textFile in textFiles)
            {
                var index = textFile.LastIndexOf("\\");
                var textFileName = textFile.Substring(index);

                System.IO.File.Move(textFile, TextFilesArchiveLocation + textFileName);
            }
        }
    }

    public void ArchiveTextFilesToArchiveLocation()
    {
        var textFiles = System.IO.Directory.GetFiles(PdfFilesLocation);

        foreach(var textFile in textFiles)
        {
            var index = textFile.LastIndexOf("\\");
            var textFileName = textFile.Substring(index);
                
            System.IO.File.Move(textFile, TextFilesArchiveLocation + textFileName);
        }
    }
}