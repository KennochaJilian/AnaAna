httpRequest = new XMLHttpRequest();

function makeRequest(pollId) {   

    if (!httpRequest) {
        alert('Giving up :( Cannot create an XMLHTTP instance');
        return false;
    }
    
    httpRequest.open('GET', `https://localhost:5001/Polls/Desactivate?pollId=${pollId}`);
    httpRequest.onreadystatechange = alertContents;
    httpRequest.send();
}

function alertContents() {
    if (httpRequest.readyState === XMLHttpRequest.DONE) {
        if (httpRequest.status === 200) {
            document.getElementById("btn-disable-poll").disabled = true
            $('.toast').toast('show');
            document.getElementById("button-submit-poll").disabled = true;

        } 
    }

}

const desactivatePoll = () => {
    let pollId = document.getElementById("pollId").value;
    makeRequest(pollId); 
   
}
