# Use the code from last week's tasks to complete this:
# eg: 6.2, 3.1T

module Genre
    POP, CLASSIC, JAZZ, ROCK = *1..4
end

$genre_names = ['Null', 'Pop', 'Classic', 'Jazz', 'Rock']

class Album
    attr_accessor :title, :artist, :genre, :tracks

    def initialize (title, artist, genre, tracks)
        @title = title
        @artist = artist
        @genre = genre
        @tracks = tracks
    end
end

class Track
    attr_accessor :name, :location

    def initialize (name, location)
        @name = name
        @location = location
    end
end

# Reads in and returns a single track from the given file
def read_track(music_file)
    name = music_file.gets.chomp.to_s()
    location = music_file.gets.chomp.to_s()

    track = Track.new(name, location)
    return track
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

# Takes an array of tracks and prints them to the terminal
def print_tracks(tracks)
    i = 0

    while i < tracks.length()
        track = tracks[i]
        print_track(track)
        i += 1
    end
end

# Takes a single track and prints it to the terminal
def print_track(track)
    puts(track.name)
    puts(track.location)
end

# Reads in and returns a single album from the given file, with all its tracks
def read_album(music_file)
    album_artist = music_file.gets.chomp()
    album_title = music_file.gets.chomp()
    album_genre = music_file.gets.chomp()

    tracks = read_tracks(music_file)

    album = Album.new(album_title, album_artist, album_genre, tracks)
    return album
end

# Takes a single album and prints it to the terminal along with all its tracks
def print_album(album)
    puts(album.artist)
    puts(album.title)
    puts('Genre is ' + album.genre.to_s)
    puts($genre_names[album.genre.to_i()])
    print_tracks(album.tracks)
end

def main()
    music_file = File.new("album.txt", "r")
    album = read_album(music_file)
    music_file.close()
    print_album(album)
end

main()