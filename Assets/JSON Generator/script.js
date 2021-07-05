document.querySelector('#newQuestion').addEventListener('click', () => {
    newQuestion();
});


document.querySelector('#export').addEventListener('click', () => {
    Export();
});

var q = 0;
var id = 0;


function newQuestion(){
    let parent = document.querySelector('.container');
    let element = document.querySelector('#question-template').cloneNode(true);
    element.setAttribute('id', 'question-'+q);
    element.classList.add('question');
    element.removeAttribute('hidden');

    parent.append(element)
    q++;
}

function deleteQuestion(context){
    let parent = context.parentNode.parentNode.parentNode;
    parent.remove();
}

function newAnswer(context){
    let parent = context.parentNode.querySelector('.answers');

    let element = document.createElement('div');
    element.className = 'd-flex align-items-center mb-2 answer';

    // input txt
    let input = document.createElement('input');
    input.classList = 'form-control answer-name';
    input.setAttribute('name', 'answer-'+id);

    // input true / false radio
    let true_i = document.createElement('input');
    true_i.setAttribute('type', 'radio');
    true_i.setAttribute('name', 'value-'+id);
    true_i.setAttribute('checked', 'true');
    true_i.setAttribute('value', 'true')
    true_i.classList = 'form-check-input mx-2';

    let true_l = document.createElement('label');
    true_l.className = 'form-check-label mx-2';
    true_l.innerText = 'True'

    let false_i = document.createElement('input');
    false_i.setAttribute('type', 'radio');
    false_i.setAttribute('name', 'value-'+id);
    false_i.setAttribute('value', 'false');
    false_i.classList = 'form-check-input mx-2';

    let false_l = document.createElement('label');
    false_l.className = 'form-check-label mx-2';
    false_l.innerText = 'False'

    // remove btn
    let rm = document.createElement('a');
    rm.className =  'btn btn-danger';
    rm.innerText = '-';
    rm.addEventListener('click', () => {
        element.remove();
    });

 
    element.append(input);
    element.append(true_i);
    element.append(true_l);
    element.append(false_i);
    element.append(false_l);
    element.append(rm);
    parent.append(element);
    id++;
}

function Export(){
    let quizz = {}
    
    let question = document.querySelectorAll('.question')
    question.forEach(q => {
        quizz[q.id] = {
            question : q.querySelector('#question').value,
            answers : {}
        }
        answers = document.querySelectorAll('.answer');
        answers.forEach(e => {
            let a = e.querySelector('.answer-name').value
            let v = e.querySelector('input[type=radio]:checked').value
            quizz[q.id].answers[a] = v;
        });
    });

    exportToJsonFile(quizz)
}

function exportToJsonFile(jsonData) {
    let dataStr = JSON.stringify(jsonData);
    let dataUri = 'data:application/json;charset=utf-8,'+ encodeURIComponent(dataStr);

    let exportFileDefaultName = 'data.json';

    let linkElement = document.createElement('a');
    linkElement.setAttribute('href', dataUri);
    linkElement.setAttribute('download', exportFileDefaultName);
    linkElement.click();
}