# creates new file writes, info and closes it
def write_data_to_file(file_name)
    a_file = File.new(file_name, "w")
     a_file.puts('5')
     a_file.puts('Fred')
     a_file.puts('Sam')
     a_file.puts('Jill')
     a_file.puts('Jenny')
     a_file.puts('Zorro')
    a_file.close()
  end
  
# opens file and reads info
def read_data_from_file(file_name)
  a_file = File.open(file_name, "r")
  count = a_file.gets.to_i()
  for i in 1..count
    puts a_file.gets()
  end
  a_file.close()
end

# creates new file, writes data to it then reads it in a different function
def main
  file_name = "test.txt"
  write_data_to_file(file_name)
  read_data_from_file(file_name)
end

# initializes program
main()