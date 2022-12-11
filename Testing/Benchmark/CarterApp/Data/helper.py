def generate_textfile(string: str, filename: str, size: int):
    strlen = len(string.encode('utf-8'))
    n = size // strlen

    file = open(filename, "w")

    [file.write(string) for _ in range(n)]
        
    file.close()

if __name__ == "__main__":
    string = "hello "
    # filename = "text_heavy.txt"
    # size = 1024 * 1024 * 4

    filename = "text_middle.txt"
    size = 1024 * 1024

    generate_textfile(string, filename, size)
