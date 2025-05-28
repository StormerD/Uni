from counter import Counter

class Clock:
  def __init__(self, hour_format):
    if hour_format == 12:
      self.hours = Counter(1, 12)
    elif hour_format == 24:
      self.hours = Counter(0, 23)
    else:
      raise ValueError("Invalid hour format. Use 12 or 24.")
    self.minutes = Counter(0, 59)
    self.seconds = Counter(0, 59)

  def tick(self, count):
    for _ in range(count):
      if self.seconds.increment(): # If seconds rolled over
        if self.minutes.increment(): # If minutes rolled over
          self.hours.increment() # If hours rolled over
  
  def reset(self):
    self.hours.reset()
    self.minutes.reset()
    self.seconds.reset()
    
  def get_time(self):
    return f"{self.hours}:{self.minutes}:{self.seconds}"
