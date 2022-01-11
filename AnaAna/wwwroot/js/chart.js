const possibleBackgroundColors = [
    'rgb(255, 99, 132)',
    'rgb(54, 162, 235)',
    'rgb(255, 206, 86)',
    'rgb(75, 192, 192)',
    'rgb(153, 102, 255)',
    'rgb(255, 159, 64)', 
    'rgb(225, 127, 147)', 
    'rgb(149, 125, 173)', 
    'rgb(242, 200, 148)', 
    'rgb(153, 194, 77)', 
]



let data = {
    labels: [],
    datasets: [{
        label: '',
        data: [],
        backgroundColor: [
            'rgb(255, 99, 132)',
            'rgb(54, 162, 235)'
        ],
        hoverOffset: 4
    }]
};

const config = {
    type: 'bar',
    data: data,

};

function getArrayOfChoicesColors (countChoices){
    let shuffledArray = possibleBackgroundColors.sort((a, b) => 0.5 - Math.random());
    return shuffledArray.slice(0,countChoices)
}


window.addEventListener("DOMContentLoaded", () => {
    let httpRequest;
    let containerResult = document.getElementById('result');
    let pollId = document.getElementById("pollId").value;


    function makeRequest(pollId) {
        httpRequest = new XMLHttpRequest();

        if (!httpRequest) {
            alert('Giving up :( Cannot create an XMLHTTP instance');
            return false;
        }
        httpRequest.onreadystatechange = alertContents;
        httpRequest.open('GET', `https://localhost:5001/Results/Charts?pollId=${pollId}`);
        httpRequest.send();
    }

    function alertContents() {
        if (httpRequest.readyState === XMLHttpRequest.DONE) {
            if (httpRequest.status === 200) {
                results = JSON.parse(httpRequest.responseText);
                data.labels = results.labels;
                data.datasets[0].data = results.countChoices.sort(function (a, b) { return b - a });
                data.datasets[0].label = results.pollTitle;
                data.datasets[0].backgroundColor = getArrayOfChoicesColors(results.countChoices.length);

                const myChart = new Chart(
                    document.getElementById('result'),
                    config
                );
            } else {
                alert('There was a problem with the request.');
            }
        }
    }
    if (containerResult) {

        makeRequest(pollId);

    }
})