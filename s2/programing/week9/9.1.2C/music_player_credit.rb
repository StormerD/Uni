# * * * * * 9.1.2 - CREDIT TASK* * * * *
require './input_functions'
# - - INPUT FUNCTIONS - -
# read_string(prompt)
# read_float(prompt)
# read_integer(prompt)
# read_integer_in_range(prompt, min, max)
# read_boolean(prompt)

# initialize Genre module
module Genre
    POP, CLASSIC, JAZZ, ROCK = *1..4
end

# names of genres
$genre_names = ['Null', 'Pop', 'Classic', 'Jazz', 'Rock']

# Album class
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

# Track Class
class Track
    attr_accessor :name, :location

    def initialize (name, location)
        @name = name
        @location = location
    end
end

# - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - #

# reads albums
def read_albums(music_file)
    albums = Array.new()
    count = music_file.gets.to_i()
    i = 0
    while i < count
        album = read_album(music_file)
        albums << album
        i += 1
    end
    return albums
end

# reads single album
def read_album(music_file)
    album_artist = music_file.gets.chomp.to_s()
    album_title = music_file.gets.chomp.to_s()
    album_label = music_file.gets.chomp.to_s()
    album_genre = music_file.gets.chomp.to_i()
    tracks = read_tracks(music_file)

    album = Album.new(album_title, album_artist, album_label, album_genre, tracks)
    return album
end

# reads tracks
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

# reads single track
def read_track(music_file)
    track_name = music_file.gets.chomp.to_s()
    track_location = music_file.gets.chomp.to_s()
    track = Track.new(track_name, track_location)
    return track
end

# adds new track to album
def ask_track
    track_name = read_string('Enter a name for the new track:')
    track_location = read_string('Enter a location for the new track:')
    track = Track.new(track_name, track_location)
    return track
end

# adds new album to Albums array
def add_album(albums)
    album_name = read_string('Enter title:')
    album_artist = read_string('Enter artist:')
    album_label = read_string('Enter label:')
    puts '1. Pop'
    puts '2. Classic'
    puts '3. Jazz'
    puts '4. Rock'
    album_genre = read_integer_in_range('Enter number of genre:', 1, 4)
    count = read_integer('Enter number of tracks:')
    tracks = Array.new()
    i = 0
    while i < count
        track = ask_track()
        tracks << track
        i += 1
    end
    album = Album.new(album_name, album_artist, album_label, album_genre, tracks)
    albums << album
    puts 'Album added: ' + album.title + ". Please enter to continue."
end

# prints all albums in file
def print_file_albums(file_music)
    count = file_music.gets.chomp.to_i()
    puts 'Number of Albums: ' + count.to_s()
    a = 0
    while a < count.to_i()
        name = file_music.gets.chomp.to_s()
        puts 'Artist name: ' + name
        aName = file_music.gets.chomp.to_s()
        puts 'Album name: ' + aName
        label = file_music.gets.chomp.to_s()
        puts 'Label name: ' + label
        genre = file_music.gets.chomp.to_i()
        puts 'Genre: ' + $genre_names[genre]
        tcount = file_music.gets.chomp.to_i()
        puts 'Number of tracks: ' + tcount.to_s()
        b = 0
        while b < tcount.to_i()
            tname = file_music.gets.chomp.to_s()
            puts 'Track name: ' + tname
            tlocation = file_music.gets.chomp.to_s()
            puts 'Track location: ' + tlocation
            b += 1
        end
        a += 1
    end
end

# prints all albums in the array
def print_album_name(album, i)
    puts 'Album Primary Key: ' + i.to_s()
    puts 'Album name: ' + album.title
    puts 'Album artist: ' + album.artist
    puts 'Album label: ' + album.label
end

# displays albums based on genre
def print_genre(albums, album_genre)
    puts 'Genre Selected: ' + $genre_names[album_genre]
    i = 0
    while i < albums.length()
        album = albums[i]
        if album.genre == album_genre
            print_album_name(album, i)
        end
        i += 1
    end
end

# prints album from primary key
def print_key(album)
    puts 'Album name: ' + album.title
    puts 'Album tracks:'
    i = 0
    while i < album.tracks.length()
        track = album.tracks[i]
        print_track(track, i)
        i += 1
    end
end

# prints tracks
def print_track(track, i)
    puts 'Track ' + i.to_s() + ': ' + track.name
    puts 'Location: ' + track.location
end

# displays menu
def albums_menu(albums)
    # menu options
    begin
        finished = false
        puts '1. Read in Albums'
        puts '2. Display in Albums'
        puts '3. Select an Album to play'
        puts '4. Add Album'
        puts '5. Exit the application'
        choice = read_integer_in_range('Please enter your choice:', 1, 5)
        case choice
            # read in albums
            when 1
                file_name = read_string('Enter file name:')
                if File.file?(file_name) == true
                    file_music = File.open(file_name, 'r')
                    print_file_albums(file_music)
                    file_music.close()
                else 
                    puts("This file does not exist. Please try again")
                end
            # display in albums
            when 2
                begin
                    twofinished = false
                    puts '1. Display all Albums'
                    puts '2. Display all Albums in genre'
                    puts '3. Back to main menu'
                    twochoice = read_integer_in_range('Please enter your choice:', 1, 3)
                    case twochoice
                        # display all albums
                        when 1
                            i = 0
                            while i < albums.length()
                                album = albums[i]
                                print_album_name(album, i)
                                i += 1
                            end
                        # display all albums in genre
                        when 2
                            puts '1. Pop'
                            puts '2. Classic'
                            puts '3. Jazz'
                            puts '4. Rock'
                            album_genre = read_integer_in_range('Enter number of genre:', 1, 4)
                            print_genre(albums, album_genre)
                        # back to main menu
                        when 3
                            twofinished = true
                        # error case
                        else
                            puts 'Please select again'
                        end
                    end until twofinished 
            # select album to play
            when 3
                pKey = read_integer('Please provide an album primary key')
                album = albums[pKey]
                print_key(album)
                tNum = read_integer('Please pick a track number')
                track = album.tracks[tNum]
                puts 'Playing track ' + track.name + ' from album ' + album.title
                sleep 3
            # add album
            when 4
                add_album(albums)
            # exit program
            when 5
                finished = true
            # error case
            else
                puts 'Please select again'
                sleep 2
            end
        end until finished
    end

# initializing function
def main
    music_file = File.new('albums.txt', 'r')
    albums = read_albums(music_file)
    music_file.close()
    albums_menu(albums)
end

main() if __FILE__ == $0