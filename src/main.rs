use std::env;
use std::fs;
use std::ops::Index;

const STRING_MODE_ARG: &str = "-string";

fn main() {
    let mut args: Vec<String> = env::args().collect();
    let mut string_mode: bool = false;
    let mut text: String = String::from("toki pona");

    args.remove(0);

    if args.contains(&String::from(STRING_MODE_ARG)) {
        string_mode = true;
        args.remove(args.iter().position(|r| r == &STRING_MODE_ARG).unwrap());
        text = args.join("");
    } else if args.len() > 0 {
        println!("{}", args[0]);
        let file_path = args.join("");
        text = fs::read_to_string(file_path)
            .expect("File unable to be read. Did you mean to include '-string'? ");
    }

    println!("{text}");
}
