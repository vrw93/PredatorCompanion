var colorA = new RgbColor(255, 0, 0);
var colorB = new RgbColor(255, 0, 0);
var colorC = RgbColors.Blue;

Console.WriteLine(colorA == colorB);
Console.WriteLine(colorA != colorC);
Console.WriteLine(colorA.Equals(colorB));
Console.WriteLine(colorA.ToHex());