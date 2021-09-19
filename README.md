# SevenZipExtractor
C# wrapper for 7z.dll (x86 and x64 included) 
- .NET Core 5.0 (windows)
- .NET Framework 4.5
- Signed Assembly (Strongname)
- 7z.dll -> v19.0.0


Every single star makes maintainer happy! ⭐

## Supported formats:
* 7Zip
* APM
* Arj
* BZip2
* Cab
* Chm
* Compound
* Cpio
* CramFS
* Deb
* Dll
* Dmg
* Exe
* Fat
* Flv
* GZip
* Hfs
* Iso
* Lzh
* Lzma
* Lzma86
* Mach-O
* Mbr
* Mub
* Nsis
* Ntfs
* Ppmd
* Rar
* Rar5
* Rpm
* Split
* SquashFS
* Swf
* Swfc
* Tar
* TE
* Udf
* UEFIc
* UEFIs
* Vhd (?)
* Wim
* Xar
* XZ
* Z
* Zip


## Wiki
* [Extracting from solid archives](https://github.com/adoconnection/SevenZipExtractor/wiki/Extracting-from-solid-archives)
* [Extract tar.gz, tag.xz](https://github.com/adoconnection/SevenZipExtractor/wiki/Extract-tar.gz,-tag.xz)

## Examples

#### Extract all
```cs
using (ArchiveFile archiveFile = new ArchiveFile(@"Archive.ARJ"))
{
    archiveFile.Extract("Output"); // extract all
}

```

#### Extract to file or stream
```cs
using (ArchiveFile archiveFile = new ArchiveFile(@"Archive.ARJ"))
{
    foreach (Entry entry in archiveFile.Entries)
    {
        Console.WriteLine(entry.FileName);
        
        // extract to file
        entry.Extract(entry.FileName);
        
        // extract to stream
        MemoryStream memoryStream = new MemoryStream();
        entry.Extract(memoryStream);
    }
}

```

#### Guess archive format from files without extensions
```cs
using (ArchiveFile archiveFile = new ArchiveFile(@"c:\random-archive"))
{
    archiveFile.Extract("Output"); 
}
```

#### Guess archive format from streams
```cs
WebRequest request = WebRequest.Create ("http://www.contoso.com/file.aspx?id=12345");
HttpWebResponse response = (HttpWebResponse)request.GetResponse();

using (ArchiveFile archiveFile = new ArchiveFile(response.GetResponseStream())
{
    archiveFile.Extract("Output"); 
}
```

## 7z.dll
7z.dll (x86 and x64) will be added to your BIN folder automatically.