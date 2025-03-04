require './input_functions'

module Genre
    POP, CLASSIC, JAZZ, ROCK = *1..4
end

Genre_names = ['Null','Pop', 'Classic',  'Jazz', 'Rock']

class Album
    attr_accessor :title, :artist, :genre
end

def read_album()
    puts "Enter Album"
    album_title = read_string("Enter album name:") # gets and stores album name
    album_artist = read_string("Enter artist name:") # gets and stores artist name
    album_genre = read_integer_in_range("Enter Genre between 1 - 4:", "1", "4") # get and store genre number
    album = Album.new()
    album.title = album_title
    album.artist = album_artist
    album.genre = album_genre

    return album
end

def print_album(album)
    puts "Album information is:"
    puts(album.title)
    puts(album.artist)
    puts("Genre is " + album.genre.to_s)
    puts Genre_names[album.genre.to_i]
end

def main() 
    album = read_album()
    print_album(album)
end

main()