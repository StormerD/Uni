import time
import tracemalloc

from clock import Clock

def space():
  print("- - - - - - - - - - - - - - - - - - - -")

def test_clock(clock, ticks):
  # Start tracing memory usage.
  tracemalloc.start()
  start_time = time.perf_counter()
  
  print(f"Testing clock with {ticks} ticks...")
  space()
  
  clock.tick(count=ticks)
  print("Clock time: ", clock.get_time())
  space()
  
  # Stop timing.
  end_time = time.perf_counter()
  
  # Get memory usage stats.
  current, peak = tracemalloc.get_traced_memory()
  
  # Calculate mb.
  currentMB = current / (1024 * 1024)
  peakMB = peak / (1024 * 1024)
  
  # Print stats.
  print(f"Execution time: {end_time - start_time:.4f} seconds")
  print(f"Current memory usage: {currentMB} MB")
  print(f"Peak memory usage: {peakMB} MB")
  
  # Stop tracing memory usage.
  tracemalloc.stop()
  
  
def main():
  creatingClock = True
  
  while creatingClock:
    # Create clock.
    space()
    command = input("Time format: (24 or 12): ").strip()
    if command not in ["24", "12"]:
      print("Invalid time format. Please try again.")
      continue
    clock = Clock(int(command))
    print(f"Clock created with {command}-hour format.")
    clock.get_time()
    space()
    break

  print("Controlling the clock...")
  space()
  controllingClock = True
  while controllingClock:
    command = input("What do you want to do? (tick count[default=1], reset, time, test count[default=1000000], exit): ").strip().lower()
    parts = command.split()
    if len(parts) == 0:
      print("No command entered. Please try again.")
      continue
    
    cmd = parts[0]
        
    if cmd == "exit":
      print("Exiting the program...")
      space()
      return
    
    if cmd == "tick":
      count = int(parts[1]) if len(parts) > 1 else 1
      clock.tick(count)
      print(f"Clock ticked {count} time(s). Current time: {clock.get_time()}")
      space()
      continue
      
    elif cmd == "reset":
      clock.reset()
      print("Clock reset.")
      space()
      continue
      
    elif cmd == "time":
      print(f"Current time: {clock.get_time()}")
      space()
      continue
      
    elif cmd == "test":
      count = int(parts[1]) if len(parts) > 1 else 1000000
      test_clock(clock, count)
      space()
      continue
      
    else:
      print("Invalid command. Please try again.")
      space()
      continue
          
  
if __name__ == "__main__":
  main()