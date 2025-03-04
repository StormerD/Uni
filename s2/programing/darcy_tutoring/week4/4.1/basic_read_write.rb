# writes data to a_file (file)
def write_data_to_file(file_name)    
    # make new file for writing
    a_file = File.new(file_name, "w")

    a_file.puts("5")
    a_file.puts("Fred")
    a_file.puts("Sam")
    a_file.puts("Jill")
    a_file.puts("Jenny")
    a_file.puts("Zorro")    
    
    a_file.close()
end


def read_data_from_file(file_name)
    # open file for reading
    a_file = File.open(file_name, "r")

    count = a_file.gets.to_i()
    i = 0
    # read lines in file
    while i < count
        puts a_file.gets()
        i = i + 1
    end

    a_file.close()
end

def main()
    file_name = "test.txt"
    # writes data to file
    write_data_to_file(file_name)
    
    # read and display file contents
    read_data_from_file(file_name)
end

main()