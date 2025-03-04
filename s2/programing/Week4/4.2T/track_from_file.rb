# define Track class
class Track
    attr_accessor :name, :location
end

# reads track info from file
def read_track(a_file)
    # defines new Track class -> track
    track = Track.new()
    track.name = a_file.gets.chomp.to_s()
    track.location = a_file.gets.chomp.to_s()
    # returns track class
    return track
end

# prints track info from file
def print_track(track)
    puts "Track name: " + track.name
    puts "Track location: " + track.location
end

# opens "track.txt" file, reads the info from it then prints it
def main()
    a_file = File.open("track.txt", "r") # linked file
    track = read_track(a_file)
    print_track(track)
end

# initialize program if linked file exists
main() if __FILE__ == $0