
const url = 'http://localhost:8002/api/fibonacci';
const table_data_container = document.querySelector('tbody');
const request_button = document.querySelector('button');
const request_input = document.querySelector('input');
const result_container = document.querySelector('.result-container');

const xhr = new XMLHttpRequest();
xhr.open('GET', url);
xhr.setRequestHeader('X-Requested-With', 'XMLHttpRequest');
xhr.responseType = 'json';
xhr.onload = function() {
    const listOfPosts = xhr.response;
    if (listOfPosts && listOfPosts.length == 0) {
        const curr_item_row = document.createElement('tr');
        const table_col = document.createElement('td');
        table_col.colSpan = 3;
        table_col.classList = 'text-center';
        table_col.textContent = 'No data available in table';
        curr_item_row.appendChild(table_col);
        table_data_container.append(curr_item_row)
    }
    else {
        for (let value of listOfPosts) {
            addDataToTable(value);
        }
    }  
};
xhr.send();

request_button.addEventListener('click', () => {
    const requestedNumber = request_input.value;
    if (requestedNumber) {
        const xhr = new XMLHttpRequest();
        xhr.open('GET', `${url}/GetNthNumberFromFibonacciSequence/${requestedNumber}`);
        xhr.setRequestHeader('X-Requested-With', 'XMLHttpRequest');
        xhr.responseType = 'json';
        xhr.onload = function () {
            const data = xhr.response;
            if (data) {
                result_container.textContent = data.result;
                addDataToTable(data);
            }
        };

        xhr.send();
    }
});

function addDataToTable(data) {
    const curr_item_row = document.createElement('tr');
    const table_col_1 = document.createElement('td');
    const table_col_2 = document.createElement('td');
    const table_col_3 = document.createElement('td');
    table_col_1.textContent = data.requestedNumber;
    curr_item_row.appendChild(table_col_1);
    table_col_2.textContent = data.result;
    curr_item_row.appendChild(table_col_2);
    table_col_3.textContent = data.requestedDateTime;
    curr_item_row.appendChild(table_col_3);
    table_data_container.append(curr_item_row);
}