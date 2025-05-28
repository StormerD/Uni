using System;
using System.Diagnostics;

class Program {
  static void Space() {
    Console.WriteLine("- - - - - - - - - - - - - - - - - - - -");    
  }

  static void TestClock(Clock clock, long ticks) {
    // Start tracing memory usage.
    Stopwatch stopwatch = Stopwatch.StartNew();
    
    Console.WriteLine("Testing clock with " + ticks + " ticks...");
    Space();
    
    clock.Tick(ticks);
    Console.WriteLine("Clock time: " + clock.GetTime());
    Space();
    
    // Stop timing.
    stopwatch.Stop();

    // Get memory usage.
    Process proc = Process.GetCurrentProcess();

    // Calculate mb.
    double seconds = stopwatch.ElapsedMilliseconds / 1000.0;
    double physical = proc.WorkingSet64 / 1048576.0;
    double peakM = proc.PeakWorkingSet64 / 1048576.0;

    // Print stats.
    Console.WriteLine("Elapsed time: {0:F3}s", seconds);
    Console.WriteLine("Physical memory usage: {0:F3} MB", physical);
    Console.WriteLine("Peak physical memory usage: {0:F3} MB", peakM);
  }

  static void Main(string[] args) {
    Console.Clear();
    bool creatingClock = true;
    Clock clock = null;

    while (creatingClock) {
      // Create a new clock.
      Space();
      Console.WriteLine("Time format (12/24): ");
      string command = Console.ReadLine().Trim().ToLower();

      if (command != "12" && command != "24") {
        Console.WriteLine("Invalid time format. Please enter 12 or 24.");
        continue;
      }
      else {
        clock = new Clock(Convert.ToInt32(command));
        Console.WriteLine("Clock created with " + command + "-hour format.");
        Console.WriteLine("Clock time: " + clock.GetTime());
        Space();
        creatingClock = false;
        break;
      }
    }

    Console.WriteLine("Controlling the clock...");
    Space();

    bool controllingClock = true;

    while (controllingClock) {
      Console.WriteLine("What do you want to do? (tick count[default=1], reset, time, test count[default=1000000], exit): ");
      string command = Console.ReadLine().Trim().ToLower();
      string[] parts = command.Split(' ');
      if (parts.Length == 0) {
        Console.WriteLine("Invalid command. Please try again.");
        continue;
      }

      string cmd = parts[0];

      if (cmd == "exit") {
        Console.WriteLine("Exiting the program...");
        Space();
        return;
      }

      else if (cmd == "tick") {
        long count = long.Parse(parts.Length > 1 ? parts[1] : "1");
        clock.Tick(count);
        Console.WriteLine("Clock ticked " + count + " time(s). Current time: " + clock.GetTime());
        Space();
        continue;
      }

      else if (cmd == "reset") {
        clock.Reset();
        Console.WriteLine("Clock reset.");
        Space();
        continue;
      }

      else if (cmd == "time") {
        Console.WriteLine("Currnet time: " + clock.GetTime());
        Space();
        continue;
      }

      else if (cmd == "test") {
        long count = long.Parse(parts.Length > 1 ? parts[1] : "1000000");
        TestClock(clock, count);
        Space();
        continue;
      }
      else {
        Console.WriteLine("Invalid command. Please try again.");
        Space();
        continue;
      }
    }
  }
}