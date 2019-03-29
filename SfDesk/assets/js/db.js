   var db = {

            insertItem: function (insertingClient) {
                // this.clients.push(insertingClient);
                $.ajax({
                    type: "POST",
                    data: insertingClient,
                    url: "add",
                    success: function (d) {
                        alert(d);
                    },
                })
            },
          
            updateItem: function (updatingClient) {
                $.ajax({
                    type: "POST",
                    data: updatingClient,
                    url: "update",
                    success: function (d) {
                        alert(d);
                    },
                })
            },

            deleteItem: function (deletingClient) {
                $.ajax({
                    type: "GET",
                    data: deletingClient,
                    url: "Delete",
                    success: function (d) {
                        alert(d);
                    },
                })
            }

        };