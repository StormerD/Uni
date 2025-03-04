# define Track class
class Track
	attr_accessor :name, :location

	def initialize (name, location)
		@name = name
		@location = location
	end
end


# reads in a single track from the given file.
def read_track(a_file)
  name = a_file.gets 
  loc = a_file.gets 
  # define new Track class -> track
  track = Track.new(name, loc)
  # return track class
  return track
end

# takes a single track and prints it to the terminal
def print_track(track)
    puts("Track name: #{track.name}")
    puts("Track location: #{track.location}")
end

# open the file and read in the tracks then print them
def main()
  file = File.new("track.txt", "r") # linked file
  track = read_track(file)
  file.close
  print_track(track)
end

#initialize program if linked file exists
main() if __FILE__ == $0