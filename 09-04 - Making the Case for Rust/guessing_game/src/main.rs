use std::io;
use std::cmp::Ordering;
use rand::Rng;

fn main() {
    println!("Guess the number!");

    //Generate random number between 1-10 inclusive
    let secret_number = rand::thread_rng().gen_range(1, 11);

    //Mark mutable because we change it
    let mut guesses: Vec<u32> = Vec::new();

    loop {
        println!("Please input your guess.");

        let mut guess = String::new();

        io::stdin().read_line(&mut guess)
            .expect("Failed to read line");

        let parsed_guess: u32 = match guess.trim().parse() {
            Ok(num) => num,
            Err(_) => continue,
        };

        println!("You guessed: {}", guess);

        guesses.push(parsed_guess);

        match parsed_guess.cmp(&secret_number) {
            Ordering::Less => println!("Too small!"),
            Ordering::Greater => println!("Too big!"),
            Ordering::Equal => {
                println!("You win!");
                break;
            }
        }
    }

    print_closing_output(guesses);
}

fn print_closing_output(all_guesses: Vec<u32>){
    if all_guesses.len() == 1
    {
        println!("Amazing! You guessed in one try!");
    }
    else
    {
        println!("You guessed in {} tries", all_guesses.len());
        for num in &all_guesses {
            println!("\t {}", num);
        }
    }
}
