
$(document).ready(function () {
    loadDashboard();
});
function loadDashboard() {
    var ctxL = document.getElementById("lineChart").getContext('2d');
    var today = new Date();
    fetch('/admin/dashboard/getall')
        .then(x => x.json())
        .then(y => {
            var myLineChart = new Chart(ctxL, {
                type: 'line',
                data: {
                    labels: [formatDate(addDays(today, -6)), formatDate(addDays(today, -5)), formatDate(addDays(today, -4)), formatDate(addDays(today, -3)), formatDate(addDays(today, -2)), formatDate(addDays(today, -1)), formatDate(addDays(today, 0))],
                    datasets: [{
                        label: "Revenue by day",
                        data: y,
                        backgroundColor: [
                            'rgba(105, 0, 132, .2)',
                        ],
                        borderColor: [
                            'rgba(200, 99, 132, .7)',
                        ],
                        borderWidth: 5
                    }
                    ]
                },
                options: {
                    responsive: true
                }
            });
        });



}
function addDays(date, days) {
    var result = new Date(date);
    result.setDate(result.getDate() + days);
    return result;
}
function formatDate(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2)
        month = '0' + month;
    if (day.length < 2)
        day = '0' + day;

    return [day, month, year].join('-');
}


