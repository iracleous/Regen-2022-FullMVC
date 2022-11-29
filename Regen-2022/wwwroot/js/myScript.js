function delet2() {
    $.ajax({
        type: "DELETE",
        url: "api/Customers1/" + $("#customerId").val(),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function () {
            $("#resultsRegion").html("success");
        },
        error: function () {
            $("#resultsRegion").html("fail");
        }
    });
}



function insert() {

    let customer = '{"name": "' + $('#customerName').val() + '", ' +
        '"buyingCategory":' + $('#customerBuyingCategory').val() + '}';


    $.ajax({
        type: "POST",
        url: "api/Customers1",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: customer,
        success: function () {
            $("#resultsRegion").html("success");
        },
        error: function () {
            $("#resultsRegion").html("fail");
        }
    });
}


function clearDiv() {
    $("#resultsRegion").html("");
}


function myLoad() {
    //ajax call

    $.ajax({
        type: "GET",
        url: "api/Customers1",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {

            result.forEach(function (item, index, arr) {
                $("#resultsRegion").append("<li>" + item.id + "   |  " + item.name
                    + "   |  " + item.buyingCategory + "</li>");
            })

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        }
    });

}
