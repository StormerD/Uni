class Counter:
  def __init__(self, min_value=0, max_value=59):
    self.min_value = min_value
    self.max_value = max_value
    self.value = min_value
  
  def increment(self): # Increment the counter.
    self.value += 1
    if self.value > self.max_value:
      self.value = self.min_value
      return True # Counter rolled over.
    return False # Counter did not roll over.
  
  def reset(self): # Reset the counter to the minimum value.
    self.value = self.min_value
    
  def __str__(self): # Get string value.
    return f"{self.value:02d}"