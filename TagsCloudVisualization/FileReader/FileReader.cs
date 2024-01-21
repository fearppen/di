﻿namespace TagsCloudVisualization.FileReader;

public class FileReader : IFileReader
{
    public string ReadText(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"File at this path {path} doesn't exist");
        }
        var x = Path.GetFullPath(path);
        var extension = path.Substring(path.LastIndexOf('.'));
        IFileReader reader = extension switch
        {
            ".txt" => new TxtReader(),
            ".doc" => new DocReader(),
            ".docx" => new DocReader(),
             _ => throw new ArgumentException($"File with extension {extension} doesn't supported")
        };
        return reader.ReadText(path);
    }
}
