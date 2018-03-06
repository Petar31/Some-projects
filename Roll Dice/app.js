/*GAME RULES:

- The game has 2 players, playing in rounds
- In each turn, a player rolls a dice as many times as he whishes. Each result get added to his ROUND score
- BUT, if the player rolls a 1, all his ROUND score gets lost. After that, it's the next player's turn
- The player can choose to 'Hold', which means that his ROUND score gets added to his GLBAL score. After that, it's the next player's turn
- The first player to reach 100 points on GLOBAL score wins the game

*/

var scores, roundScores, activePlayer, diceDom, gamePlay, inputVal;

function init(){
    
scores = [0,0];
roundScores = 0;
activePlayer = 0;
    gamePlay = true;
    inputVal = document.getElementsByTagName('input')[0].value;
    
    document.querySelector('.dice').style.display = "none";
document.getElementById('score-0').textContent = 0;
document.getElementById('score-1').textContent = 0;
document.getElementById('current-0').textContent = 0;
document.getElementById('current-1').textContent = 0;
    
    document.querySelector('#name-0').textContent = 'Player 1';
     document.querySelector('#name-1').textContent = 'Player 2';
    
    document.querySelector('.player-0-panel').classList.remove('winner');
    document.querySelector('.player-1-panel').classList.remove('winner');
    document.querySelector('.player-0-panel').classList.remove('active');
    document.querySelector('.player-0-panel').classList.add('active');
     document.querySelector('.player-1-panel').classList.remove('active');
};

init();
//dice = Math.floor(Math.random()*6) + 1;
//console.log(dice);

//document.querySelector('#current-' + activePlayer).textContent = dice;



document.querySelector('.btn-roll').addEventListener('click', function(){
    if(gamePlay && inputVal > 0){
         //1.random number
   var dice = Math.floor(Math.random()*6) + 1;
    
    //2.display the result
    diceDom = document.querySelector('.dice');
    diceDom.style.display = "block";
    diceDom.src = 'images/dice-' + dice + '.png';
    
    
    //3.upadete the round score ig=f the number was not 1
    if(dice!==1){
        //add score
        roundScores += dice;
        document.querySelector('#current-' + activePlayer).textContent = roundScores;
    }else{
        //next player
        nextPlayer();
    }
    }else{
        alert("Please insert number greather then 0");
    }
    
   
    
    
})

document.getElementsByClassName('btn-hold')[0].addEventListener('click', function(){
    if(gamePlay){
         //1.add current score to global
    scores[activePlayer] += roundScores;
    
    //2.update ui
    
    document.querySelector("#score-" + activePlayer).textContent = scores[activePlayer];
   
    
    //3.if player won the game
    
    if(scores[activePlayer]>=inputVal){
        document.querySelector('#name-' + activePlayer).textContent = 'Winner';
        diceDom.style.display = "none";
        document.querySelector('.player-' + activePlayer + '-panel').classList.add('winner');
        document.querySelector('.player-' + activePlayer + '-panel').classList.remove('active');
        gamePlay = false;
        
    }else{
        nextPlayer();
    }
    }
    })

function nextPlayer(){
     activePlayer==0 ? activePlayer=1 : activePlayer=0;
        roundScores = 0;
        
       // document.getElementById('current-' + activePlayer).textContent = 0;
        document.getElementById('current-0').textContent = 0;
        document.getElementById('current-1').textContent = 0;
        
        document.querySelector('.player-0-panel').classList.toggle('active');
        document.querySelector('.player-1-panel').classList.toggle('active');
         diceDom.style.display = "none";
}

document.querySelector('.btn-new').addEventListener('click', function(){
    init();
    alert("You started a new game");
    
} );














