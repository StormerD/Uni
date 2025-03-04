# define Track class
class Track
	attr_accessor :name, :location

	def initialize (name, location)
		@name = name
		@location = location
	end
end

# returns an array of tracks read from the given file
def read_tracks(music_file)

  count = music_file.gets().to_i()
  # define new Array -> tracks
  tracks = Array.new()
  i = 0
  while i < count
    track = read_track(music_file)
    tracks << track
    i = i + 1
  end
  # return tracks class
  return tracks
end

# reads in a single track from the given file.
def read_track(a_file)
  name = a_file.gets.chomp.to_s()
  location = a_file.gets.chomp.to_s()
  # defines new Track class -> track
  track = Track.new(name, location)
  # returns track class
  return track
end


# takes an array of tracks and prints them to the terminal
def print_tracks(tracks)
  count = tracks.length().to_i
  i = 0
  while i < count
    track = tracks[i]
    puts track.name.to_s
    puts track.location.to_s
    i = i + 1
  end
end

# takes a single track and prints it to the terminal
def print_track(track)
  puts(track.name)
	puts(track.location)
end

# open the file and read in the tracks then print them
def main()
  a_file = File.new("input.txt", "r") # linkned file
  tracks = read_tracks(a_file)
  a_file.close()
  
  # print all the tracks
  print_tracks(tracks)
end

# initializes main if the linked file exists
main() if __FILE__ == $0