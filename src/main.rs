mod tree;

use std::{env, io};
use std::fs;
use std::fs::File;
use std::io::{Read, Write};
use std::path::PathBuf;
use bitvec::prelude::*;

fn main() {
    let mut args: Vec<String> = env::args().collect();

    args.remove(0);

    if args.len() > 0 {
        let mut path = PathBuf::from(args.join(""));
        let mut new_path = PathBuf::new();
        let extension = path.extension()
            .expect("File unable to be read.");
        if extension == "txt" {
            new_path = path.with_extension("toki");
            let text = fs::read_to_string(path)
                .expect("File unable to be read.");

            let vec = txt_to_toki(&text);

            File::create(new_path)
                .expect("New file unable to be created.")
                .write_all(vec.as_raw_slice())
                    .expect("New file unable to be written to.");

        } else if extension == "toki" {
            new_path = path.with_extension("txt");
            let vec = file_to_bits(File::open(path)
                .expect("File unable to be read."));

            let text = toki_to_txt(vec);

            File::create(new_path)
                .expect("New file unable to be created.")
                .write_all(text.as_bytes())
                    .expect("New file unable to be written to.")
        } else {
            panic!("File unable to be read.\nFile must end in .toki or .txt")
        }





    }
}

fn txt_to_toki(text: &str) -> BitVec<u8, Msb0> {
    let tokens = tokenize(text);
    string_to_bits("default")
}

fn tokenize(text: &str) -> Vec<&str> {
    // TODO: This function should seperate out each toki pona word and tokenize them. It should also separate out the stray Unicode characters into two tokens each.
    Vec::new()
}

fn toki_to_txt(bits: BitVec<u8, Msb0>) -> String {
    String::from("default")
}

fn file_to_bits(mut file: File) -> BitVec<u8, Msb0> {
    let mut ret: BitVec<u8, Msb0> = BitVec::new();
    io::copy(&mut file, &mut ret)
        .expect("File unable to be read.");

    ret
}

fn string_to_bits(string: &str) -> BitVec<u8, Msb0> {
    string.as_bits::<Msb0>().to_bitvec()
}