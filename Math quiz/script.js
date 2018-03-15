var play = false;
var scoreDiv = document.getElementById('score');
var timeDiv = document.getElementById('time');
var time = 60;
var action;
var startGameBtn = document.getElementById('startGame');
var questionPanel = document.getElementById('questionPanel');
var res;
var correct = document.getElementById('correct');
var wrong = document.getElementById('wrong');
var gameOver = document.getElementById('gameOver');

(function(){
    startGameBtn.addEventListener('click', function(){
    if(play == false){
        play = true;
        gameOver.style.visibility = 'hidden';
         startCount();
        score = 0;
        questions();
        
    }else{
        location.reload();
    }
});
    for(var i=1; i<5; i++){
    document.getElementById("btn" + i).addEventListener('click', answer)
}
    
})();


function startCount(){
     action = setInterval(function()
    {
        time -= 1;
        timeDiv.textContent = time; 
         startGameBtn.textContent = "Reset game";
        if(time == 0){
            stopCount();
            play = false;
            gameOver.innerHTML = "<h1>Game over</h1> <h2>Your score is: "+score+"</h2>";
            gameOver.style.visibility = 'visible';
            startGameBtn.textContent = "Start game";
        } 
         if(time < 10) timeDiv.style.color = 'red';
         
     },1000);
}

function stopCount(){
    clearInterval(action);
    time = 60;
}

function questions(){
    var x = genNum();
     var y = genNum();
    res = x * y ;
    questionPanel.textContent = x + " * " + y;
    var correctPos = 1 + Math.round(3*Math.random());
    console.log(correctPos);
    document.getElementById('btn' + correctPos).innerHTML = res;
    
    
    for(var i=1; i<5; i++){
        if(i === correctPos){
            continue;
        }
        var wrongAnswer = genNum() * genNum();
        if(wrongAnswer == res) wrongAnswer =  genNum() * genNum() ;
          // console.log(wrongAnswer);
         document.getElementById("btn" + i).innerHTML = wrongAnswer;
    }
}
function genNum(){
     var x = 1 + Math.round(9*Math.random());
    return x;
}

function answer(){
    if(play == true){
        if(this.textContent == res ){
            score++;
            scoreDiv.textContent = score;
            show(correct);
            hide(wrong);
            questions();
            if(score > 0)scoreDiv.style.color = 'green';
                
            setTimeout(function(){hide(correct)}, 1000);
        }else{
            hide(correct);
            show(wrong);
            setTimeout(function(){hide(wrong)}, 1000);
        }
        
        
    }
    
}

function hide(id){
    id.style.visibility = 'hidden';
}

function show(id){
    id.style.visibility = 'visible';
}


       
       
       
       
       
       
       
       
       
       
       

