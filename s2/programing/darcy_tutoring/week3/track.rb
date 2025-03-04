require "./input_functions"

class Track
    attr_accessor :name, :location

    def initialize (name, location)
        @name = name
        @location = location
    end
end

def read_track() 
    # asks track name
    name = read_string("Enter track name:")
    # asks track location
    location = read_string("Enter track location:")
    track = Track.new(name, location)
    return track
end

def print_track(track)
    puts("Track name: " + track.name)
    puts("Track location: " + track.location)
end

def main() 
    track = read_track()
    print_track(track)
end

main() if __FILE__ == $0