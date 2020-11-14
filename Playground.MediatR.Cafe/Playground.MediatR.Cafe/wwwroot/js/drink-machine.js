"use strict";

(function () {
    var machineConn = new signalR.HubConnectionBuilder().withUrl("/machine").build();
    machineConn.serverTimeoutMilliseconds = 10000;

    var buttonCoffee = document.querySelector('#buttonCoffee');
    buttonCoffee.disabled = true;
    buttonCoffee.addEventListener("click", function (event) {
        machineConn.invoke("RequestDrink", 1);
    });

    var buttonLatte = document.querySelector('#buttonLatte');
    buttonLatte.disabled = true;
    buttonLatte.addEventListener("click", function (event) {
        machineConn.invoke("RequestDrink", 2);
    });

    var buttonCappuccino = document.querySelector('#buttonCappuccino');
    buttonCappuccino.disabled = true;
    buttonCappuccino.addEventListener("click", function (event) {
        machineConn.invoke("RequestDrink", 3);
    });

    var buttonTea = document.querySelector('#buttonTea');
    buttonTea.disabled = true;
    buttonTea.addEventListener("click", function(event) {
        machineConn.invoke("RequestDrink", 4);
    });

    var spanServerResponse = document.querySelector('#spanServerResponse');
    var spanError = document.querySelector('#spanError');

    machineConn.on("Ready", function (dosesPerSlot) {
        buttonCoffee.innerHTML = 'Coffee (' + dosesPerSlot.coffee + ' left)';
        if (dosesPerSlot.coffee > 0)
            buttonCoffee.disabled = false;

        buttonLatte.innerHTML = 'Latte (' + dosesPerSlot.latte + ' left)';
        if (dosesPerSlot.latte > 0)
            buttonLatte.disabled = false;

        buttonCappuccino.innerHTML = 'Cappuccino (' + dosesPerSlot.cappuccino + ' left)';
        if (dosesPerSlot.cappuccino > 0)
            buttonCappuccino.disabled = false;

        buttonTea.innerHTML = 'Tea (' + dosesPerSlot.tea + ' left)';
        if (dosesPerSlot.tea > 0)
            buttonTea.disabled = false;
    });

    machineConn.on("Serve", function (drinkName, remainingDoses) {
        spanServerResponse.innerHTML = 'Your ' + drinkName + ' is ready!';

        document.querySelector('#button' + drinkName).innerHTML = drinkName + ' (' + remainingDoses + ' left)';

        if (remainingDoses == 0)
            document.querySelector('#button' + drinkName).disabled = true;
    });

    machineConn.start()
        .then(function () {
            machineConn.invoke("GetAvailableDoses");
        })
        .catch(function (error) {
            spanError.innerHTML = 'Unable to connect to the server. Please press F5.';
        });

    machineConn.onclose(function (error) {
        spanError.innerHTML = 'Connection lost. Please press F5';
    })
})();