class Track
  attr_accessor :name, :location

  def initialize (name, location)
    @name = name
    @location = location
  end
end

# Returns an array of tracks read from the given file
def read_tracks(music_file)
  count = music_file.gets().to_i()
  tracks = Array.new()
  i = 0

  while i < count
    track = read_track(music_file)
    tracks << track
    i += 1
  end

  return tracks
end

# reads in a single track from the given file.
def read_track(a_file)
  name = a_file.gets.chomp.to_s()
  location = a_file.gets.chomp.to_s()

  track = Track.new(name, location)
  return track
end


# Takes an array of tracks and prints them to the terminal
def print_tracks(tracks)
  i = 0

  while i < tracks.length.to_i()
    track = tracks[i]
    i += 1
  end
end

# Takes a single track and prints it to the terminal
def print_track(track)
  puts(track.name)
    puts(track.location)
end

# Open the file and read in the tracks then print them
def main()
  a_file = File.new("input.txt", "r") # open for reading
  tracks = read_tracks(a_file)
  a_file.close()
  
  # Print all the tracks
  print_tracks(tracks)
end

main()