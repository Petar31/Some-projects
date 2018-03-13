var taskList = document.getElementById('taskList');
var inputTask = document.getElementById('inputTask');
var addBtn = document.getElementById('addBtn');
inputTask.focus();

class List{
    constructor(task){
        this.task = task;
    }
    
    print(){
        var li = document.createElement('li');
       var btn = document.createElement('button');
        btn.textContent = 'X';
        btn.className = 'btn btn-danger';
        
        li.innerHTML = this.task;
        li.appendChild(btn);
        li.className = "list-group-item";
        btn.addEventListener('click', remove);
        taskList.appendChild(li);
        
    }
}

addBtn.addEventListener('click', printLi);

function printLi(){
    //var input = inputTask.value;
    if(inputTask.value == ""){
        alert("Please enter some text")
    }else{
           var list1 = new List(inputTask.value);
    list1.print();
    inputTask.value = "";
    }
    inputTask.focus();
 
}

function remove(){
    this.parentElement.style.display = 'none';
     inputTask.focus();
}


