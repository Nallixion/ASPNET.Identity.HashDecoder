// See https://aka.ms/new-console-template for more information
using Hashcat.ASPNET.Identity;
using NetDevPack.Utilities;
using AspNetIdentityHashInfo = Hashcat.ASPNET.Identity.AspNetIdentityHashInfo;

var text = new WenceyWang.FIGlet.AsciiArt("ASP2hashcat");
Console.WriteLine (text);

var hashDemoV3 = "AQAAAAEAACcQAAAAEG7xx8smhzcYFaAhPSRj1rgxfAoqKBv4WM/4R+Z0SvFxtxuMkfgBS28p1MQzvV0OeQ==";
var hashDemoV2 = "AKfi6N5zPeZPjSBozm7Bt8YzqM/WpgoAU40cbMTIb2y5v/9DzxjxSOwgNQLNEiYadg==";
var hashDemoBase64Decoded = hashDemoV3.FromBase64();
var hex = BitConverter.ToString(hashDemoBase64Decoded).Replace("-", "").ToLower();

Console.WriteLine($"Demo Hash: {hex}");

string HexHash = hashDemoV3.FromBase64().ToPlainHexDumpStyle();
string Hash = hashDemoV3;
var hashVersion = HexHash.Substring(0, 2);
Console.Write(hashVersion);

var asphash = new AspNetIdentityHashInfo(hashDemoV3);
Console.ResetColor();
Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.Write(asphash.ShaType);
Console.ResetColor();
Console.Write(":");
Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.Write(asphash.IterCount);
Console.ResetColor();
Console.Write(":");
Console.ForegroundColor = ConsoleColor.DarkMagenta;
Console.Write(asphash.Salt);
Console.ResetColor();
Console.Write(":");
Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.WriteLine(asphash.SubKey);
Console.ResetColor();

var hashDemoBase64Decodedv2 = hashDemoV2.FromBase64();
var hexv2 = BitConverter.ToString(hashDemoBase64Decodedv2).Replace("-", "").ToLower();

Console.WriteLine($"Demo Hash: {hexv2}");
var asphashv2 = new AspNetIdentityHashInfo(hashDemoV2);
Console.ResetColor();
Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.Write(asphashv2.ShaType);
Console.ResetColor();
Console.Write(":");
Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.Write(asphashv2.IterCount);
Console.ResetColor();
Console.Write(":");
Console.ForegroundColor = ConsoleColor.DarkMagenta;
Console.Write(asphashv2.Salt);
Console.ResetColor();
Console.Write(":");
Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.WriteLine(asphashv2.SubKey);
Console.ResetColor();

//hashDemoV3 sha256:10000:bvHHyyaHNxgVoCE9JGPWuA==:MXwKKigb+FjP+EfmdErxcbcbjJH4AUtvKdTEM71dDnk=

//hashDemo 