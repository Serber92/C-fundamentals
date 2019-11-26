using System;

namespace phone
{
  public abstract class Phone
  {
    private string _versionNumber;
    private int _batteryPercentage;
    private string _carrier;
    private string _ringTone;
    public Phone(string versionNumber, int batteryPercentage, string carrier, string ringTone)
    {
      _versionNumber = versionNumber;
      _batteryPercentage = batteryPercentage;
      _carrier = carrier;
      _ringTone = ringTone;
    }
    public abstract void DisplayInfo();
    public string versionNumber{get {return _versionNumber;}}
    public int batteryPercentage { get { return _batteryPercentage; } }
    public string carrier { get { return _carrier; } }
    public string ringTone { get { return _ringTone; } }
  }
  public interface IRingable
  {
    string Ring();
    string Unlock();
  }
  class Nokia : Phone, IRingable
  {
    public Nokia(string versionNumber, int batteryPercentage, string carrier, string ringTone)
      : base(versionNumber, batteryPercentage, carrier, ringTone) { }
    public string Ring()
    {
      return ringTone;
    }
    public string Unlock()
    {
      return "pososi";
    }
    public override void DisplayInfo()
    {
      Console.WriteLine($"Nokia {versionNumber} {batteryPercentage} {carrier} {ringTone}");         
    }
  }
  public class Galaxy : Phone, IRingable
  {
    public Galaxy(string versionNumber, int batteryPercentage, string carrier, string ringTone)
        : base(versionNumber, batteryPercentage, carrier, ringTone) { }
    public string Ring()
    {
      return ringTone;
    }

    public string Unlock()
    {
      return "Vstav chlen";
    }
    public override void DisplayInfo()
    {
      Console.WriteLine($"Galaxy {versionNumber} {batteryPercentage} {carrier} {ringTone}");
    }
  }
    class Program
    {
        static void Main(string[] args)
        {
      Galaxy s8 = new Galaxy("s8", 100, "T-Mobile", "Dooo do doo dooo");
      Nokia elevenﬂundred = new Nokia("1160", 66, "Metro PCS", "Ringgg ring ringgg");

      s8.DisplayInfo();
      Console.WriteLine(s8.Ring());
      Console.WriteLine(s8.Unlock());
      Console.WriteLine("");

      elevenﬂundred.DisplayInfo();
      Console.WriteLine(elevenﬂundred.Ring());
      Console.WriteLine(elevenﬂundred.Unlock());
      Console.WriteLine("");

    }
    }
}
