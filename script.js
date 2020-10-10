new Vue({
	el: '#main',
	
	 data: {
       

        result: "",
        responseAvailable: false,
        apiKey: 'bc4b0be2fdd660c46df39aa418423b6d'

    },

    methods: {

        fetchAPIData() {

            this.responseAvailable = false;

            fetch("https://dev-kfgfly.marketforce.com/api/api/filterhelp", {
                "method": "GET",
                "headers": {
                    "x-rapidapi-host": "dev-kfgfly.marketforce.com",
                    "x-rapidapi-key": this.apiKey
                    

                }

            })
                .then(response => {
                    if (response.ok) {
                        return response.json()
                    } else {
                        alert("Server returned " + response.status + " : " + response.statusText);
                    }
                })
                .then(response => {
                    this.result = response.body;
                    this.responseAvailable = true;
                })
                .then(data => console.log(data))
                .catch(err => {
                    console.log(err);
                });


        }
    }
});
	
