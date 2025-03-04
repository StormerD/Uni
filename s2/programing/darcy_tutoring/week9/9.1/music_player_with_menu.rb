require './input_functions'

<<<<<<<<< Temporary merge branch 1
=========
module Genre
    POP, CLASSIC, JAZZ, ROCK = *1..4
end

$genre_names = ['Null', 'Pop', 'Classic', 'Jazz', 'Rock']

>>>>>>>>> Temporary merge branch 2
class Album
    attr_accessor :title, :artist, :label, :genre, :tracks

    def initialize (title, artist, label, genre, tracks)
        @title = title
        @artist = artist
        @label = label
        @genre = genre
        @tracks = tracks
    end
end

class Track 
    attr_accessor :name, :location, :duration

    def initialize (name, location, duration)
        @name = name
        @location = location 
        @duration = duration
    end
end

# reads single track from file
def read_track(music_file)
<<<<<<<<< Temporary merge branch 1
    name = music_file.get.chomp()
    location = music_file.get.chomp()
    duration = music_file.get.chomp()
=========
    name = music_file.gets.chomp()
    location = music_file.gets.chomp()
    duration = music_file.gets.chomp()
>>>>>>>>> Temporary merge branch 2

    track = Track.new(name, location, duration)
    return track
end

# reads multiple tracks from file
def read_tracks(music_file)
    count = music_file.gets.chomp.to_i()
    tracks = Array.new()
    i = 0

    while i < count
        track = read_track(music_file)
        tracks << track
        i += 1
    end
    return tracks
end

# reads a single album from file
def read_album(music_file)
    artist = music_file.gets.chomp()
    title = music_file.gets.chomp()
    label = music_file.gets.chomp()
    genre = music_file.gets.chomp()

    tracks = read_tracks(music_file)

    album = Album.new(title, artist, label, genre, tracks)
    return album
end

# read multiple albums from file
def read_albums(music_file)
    count = music_file.gets.chomp.to_i()
    albums = Array.new()
    i = 0

    while i < count
        album = read_album(music_file)
        albums << album
        i += 1
    end
    return albums
end

<<<<<<<<< Temporary merge branch 1
def main()
    music_file = File.new("album.txt", "r")
    albums = read_albums(music_file)
    music_file.close()
end
=========
def display_track(track)
    puts("Track Name: " + track.name)
    puts("Track Location: " + track.location)
    puts("Track Duration: " + track.duration)
end

def display_tracks(tracks)
    i = 0
    while i < tracks.length()
        track = tracks[i]
        display_track(track)
        i += 1
    end
end

def display_album(album, i)
    puts("Album ID: " + i.to_s())
    puts("Album Title: " + album.title)
    puts("Album Artist: " + album.artist)
    puts("Album Label: " + album.label)
    puts("Album Genre: " + album.genre)
    puts($genre_names[album.genre.to_i()])
    puts("Number of Tracks: " + album.tracks.length.to_s())
    display_tracks(album.tracks)
end

# displays all albums
def display_all_albums(albums)
    i = 0
    while i < albums.length()
        album = albums[i]
        puts("- - - - - - - - - - - - - - -")
        display_album(album, i)
        i += 1
    end
end

def display_albums_genre(albums)
    choice = read_integer_in_range("Please select a genre:", 1, 4)
    x = false
    i = 0
    while i < albums.length()
        album = albums[i]
        # album.genre
        # choice
        if album.genre.to_i() == choice
            puts("- - - - - - - - - - - - - - -")
            display_album(album, i)
            x = true
        end
        i += 1
    end
    if x == false
        puts("- - - - - - - - - - - - - - -")
        puts("Could not find albums with the genre " + $genre_names[choice])
    end
end

# handles menu to display albums to user
def display_albums(albums)
    finished = false
    begin
        puts("- - - - - - - - - - - - - - -")
        puts("1. Display All Albums")
        puts("2. Display Albums By Genre")
        puts("3. Exit to Main Menu")
        choice = read_integer_in_range("Please select a menu:", 1, 3)
        case choice
        # displays all albums
        when 1
            display_all_albums(albums)
        when 2
            i = 1
            puts("- - - - - - - - - - - - - - -")
            while i < $genre_names.length()
                puts(i.to_s() + ". " + $genre_names[i])
                i += 1
            end

            display_albums_genre(albums)
        when 3
            finished = true
        end
    end until finished
end

def display_album_id(albums)
    album_id = read_integer("Please enter album id: ")
    puts("Album " + album_id.to_s() = " has been selected")
    album = albums[album_id.to_i()]
    tracks = album.tracks
    i = 0
    if tracks.length() > 0

        while i < tracks.length()
            track = tracks[i]
            puts("Track ID: " + i.to_s())
            display_track(track)
            i += 1
        end
        track_id = read_integer("Please enter track id: ")
        track = tracks[track_id]
        puts("Playing track " + track.name.to_s() + " from album " + album.title)
    else
        puts("Album does not have any tracks")
    end 
end

# handles main menu
def main()
    finished = false
    begin
        puts("- - - - - - - - - - - - - - -")
        puts("1. Read in Albums")
        puts("2. Display Albums")
        puts("3. Select an Album to play")
        puts("5. Exit the application")
        choice = read_integer_in_range("Please select a menu:", 1, 5)
        case choice
        # prompts user to insert name of file to be read into program
        when 1
            puts("- - - - - - - - - - - - - - -")
            file_name = read_string("Enter the file name:")
            music_file = File.open(file_name, "r")
            albums = read_albums(music_file)
            music_file.close()
            puts("The file has been uploaded")
        # user selects to display albums
        when 2
            display_albums(albums)
        # prompts users for album id number
        # lists all tracks for that album and track numbers
        # asks user to select track number
        # displays system message for playing track and adds delay
        when 3
            puts("- - - - - - - - - - - - - - -")
            display_album_id(albums)
        when 5
            finished = true
        end
    end until finished
end

main()
>>>>>>>>> Temporary merge branch 2
