(function() {

    var db = {

            
        insertItem: function(insertingClient) {
            // this.clients.push(insertingClient);
            alert("tatti");
        },

        updateItem: function(updatingClient) { },

        deleteItem: function(deletingClient) {
            var clientIndex = $.inArray(deletingClient, this.clients);
            this.clients.splice(clientIndex, 1);
        }

    };
   
    window.db = db;


   



}());