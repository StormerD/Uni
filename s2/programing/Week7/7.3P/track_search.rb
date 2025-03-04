# linked file
require './input_functions'

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
  	tracks = Array.new()
	i = 0

  # put a while loop here which increments an index to read the tracks
	while (i < count)
		track = read_track(music_file)
		tracks << track
		i += 1
	end

	return tracks
end

# reads in and returns a single track from the given file
def read_track(music_file)
	name = music_file.gets.chomp.to_s()
 	location = music_file.gets.chomp.to_s()
	# define new Track class -> track
	track = Track.new(name, location)
	# return track class
	return track
end

# takes an array of tracks and prints them to the terminal
def print_tracks(tracks)
	# print all the tracks use: tracks[x] to access each track.
	count = tracks.length()
	i = 0
	while i < count
		print_track(tracks[i])
		i += 1
	end
end

# takes a single track and prints it to the terminal
def print_track(track)
  	puts(track.name)
	puts(track.location)
end


# search for track by name.
# returns the index of the track or -1 if not found
def search_for_track_name(tracks, search_string)
	count = tracks.length()
	i = 0
	found_index = -1

	while (i < count)
		track = tracks[i]
		if (search_string == track.name)
			found_index = i
		end
		i += 1
	end
	# return index
	return found_index
end


# reads in an Album from a file and then prints all the album to the terminal
def main()
  	music_file = File.new("album.txt", "r")
	tracks = read_tracks(music_file)
  	music_file.close()
	print_tracks(tracks)
  	search_string = read_string("Enter the track name you wish to find: ")
  	index = search_for_track_name(tracks, search_string)
  	if index > -1
   		puts "Found " + tracks[index].name
		puts " at " + index.to_s()
  	else
    	puts "Entry not Found"
  	end
end

# initializes main if the linked file exists
main() if __FILE__ == $0