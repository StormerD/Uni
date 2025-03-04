class Track
    attr_accessor :name, :location

    def initialize (name, location)
        @name = name
        @location = location
    end
end

def read_track(a_file)
    name = a_file.gets.chomp()
    location = a_file.gets.chomp()

    track = Track.new(name, location)
    return track
end

def print_track(track)
    puts ("Track name: " + track.name)
    puts ("Track location: " + track.location)
end

def main()
    file_name = "track.txt"
    a_file = File.open(file_name, "r")

    track = read_track(a_file)
    a_file.close()
    print_track(track)
end

main()