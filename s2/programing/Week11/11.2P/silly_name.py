# prints silly for name
def print_silly_name(name):
    print(f"{name} is a")
    index = 0
    while (index < 60):
        print("silly ", end="")
        index += 1
    print("name!")

# main function
def main():
    name = input("What is your name? ")
    if (name == "Kayla") or (name == "kayla") or (name == "Dylan") or (name == "dylan"):
        print(f"{name} is an awesome name!")
    else:
        print_silly_name(name)
    return

main()