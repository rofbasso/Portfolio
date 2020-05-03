let userScore = 0;
let computerScore = 0;
const userScore_span = document.getElementById("user-score");
const computerScore_span = document.getElementById("computer-score");
const scoreBoard_div = document.querySelector(".score-board");
const result_p = document.querySelector(".result > p");
const rock_div = document.getElementById("rock");
const paper_div = document.getElementById("paper");
const scissors_div = document.getElementById("scissors");

function getComputerChoice(){
    const choices = ["rock", "paper", "scissors"];
    const randomNumber = Math.floor(Math.random() * 3);
    return choices[randomNumber];
}

function win(userChoise, computerChoise){
    const smallUserWord = "user".fontsize(3).sub();
    const smallCompWord = "comp".fontsize(3).sub();
    const userChoice_div =  document.getElementById(userChoise);
    userScore++;
    userScore_span.innerHTML = userScore;
    computerScore_span.innerHTML = computerScore;
    result_p.classList.add('green-result');  
    setTimeout(() => result_p.classList.remove('green-result'), 300);    
    result_p.innerHTML = `${userChoise}${smallUserWord} beats ${computerChoise}${smallCompWord}. You Win!`;
    userChoice_div.classList.add('green-glow');    
    setTimeout(() => userChoice_div.classList.remove('green-glow'), 300);
}

function lose(userChoise, computerChoise){    
    const smallUserWord = "user".fontsize(3).sub();
    const smallCompWord = "comp".fontsize(3).sub();
    const userChoice_div =  document.getElementById(userChoise);
    computerScore++;
    computerScore_span.innerHTML = computerScore;
    userScore_span.innerHTML = userScore;
    result_p.classList.add('red-result');  
    setTimeout(() => result_p.classList.remove('red-result'), 300);  
    result_p.innerHTML = `${userChoise}${smallUserWord} loses to ${computerChoise}${smallCompWord}. You Lost!`;
    userChoice_div.classList.add('red-glow');    
    setTimeout(function() {userChoice_div.classList.remove('red-glow')}, 300);
}

function draw(userChoise, computerChoise){
    const smallUserWord = "user".fontsize(3).sub();
    const smallCompWord = "comp".fontsize(3).sub();
    const userChoice_div =  document.getElementById(userChoise);
    result_p.classList.add('gray-result');  
    setTimeout(() => result_p.classList.remove('gray-result'), 300);  
    result_p.innerHTML = `${userChoise}${smallUserWord} equals ${computerChoise}${smallCompWord}. It's a draw!`;
    userChoice_div.classList.add('gray-glow');    
    setTimeout(function() {userChoice_div.classList.remove('gray-glow')}, 300);
}

function game(userChoice){
    const computerChoice = getComputerChoice();
    switch(userChoice + computerChoice){
        case "rockscissors":
        case "paperrock":
        case "scissorspaper":
            win(userChoice, computerChoice);
            break;
        case "rockpaper":
        case "paperscissors":
        case "scissorsrock":
            lose(userChoice, computerChoice);
            break;
        case "rockrock":
        case "paperpaper":
        case "scissorsscissors":
            draw(userChoice, computerChoice);
            break;
    }
}

function main(){   

    rock_div.addEventListener('click', function(){
        game("rock")
    })

    paper_div.addEventListener('click', function(){
        game("paper")
    })

    scissors_div.addEventListener('click', function(){
        game("scissors")
    })
}

main();