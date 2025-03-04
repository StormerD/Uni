# linked file
require "./input_functions"

# defines Track class
class Track
    attr_accessor :name, :location
end

# reads track info from user input
def read_track()
    track_name = read_string("Enter track name:")
    track_location = read_string("Enter track location:")
    # stores track info in new Track class -> Track
    track = Track.new()
    track.name = track_name
    track.location = track_location

    # Return track class
    return track
end

# prints info from track class
def print_track(track)
    puts("Track name: " + track.name)
    puts("Track location: " + track.location)
end

# reads track from user input then prints it
def main()
    track = read_track()
    print_track(track)
end

# initializes program if linked file exists
main() if __FILE__ == $0