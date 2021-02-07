// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var app = new Vue({
    el: '#app',
    data: {
        message: 'Mars Rovers Mission Control',
        plateuSize: {
            width: 0,
            height:0
        },
        plateu: null,
        directions: ["N", "E", "S", "W"],
        newRover: {
            x: 0,
            y: 0,
            direction: "N",
            commands: ['M', 'L', 'R'],
            selectedCommand: ''
        },
        rovers: [],
        settingPlateu: false,
        errors: {}
    },
    computed: {
        maxX: function () {
            return this.plateu != null ? this.plateu.widthArr.length - 1 : 0;
        },
        maxY: function () {
            return this.plateu != null ? this.plateu.heightArr.length - 1: 0;
        },
        
    },
    methods: {
        displayError: function (fieldName) {
            return this.errors[fieldName] != undefined ? this.errors[fieldName][0] : "";
        },
        setPlateu: function () {
            
            this.rovers = [];
            this.settingPlateu = true;
            axios.get(`/api/mission/setplateu?Width=${this.plateuSize.width}&Height=${this.plateuSize.height}`)
                .then(response => {
                    this.errors = {};
                    const height = [...new Array(parseInt(response.data.width)).keys()];
                    const width = [...new Array(parseInt(response.data.height)).keys()].reverse();
                    this.plateu = {
                        widthArr: height,
                        heightArr: width
                    };
                }).catch((error) => {
                    if (error.response.data != undefined && error.response.data.errors != undefined) {
                        this.errors = error.response.data.errors;
                    }
                    
                })
                .then(() => { this.settingPlateu = false; });
        },
        resetPlateu: function () {
            //Require to do the API call here
            this.plateu = null;
            this.rovers = [];
        },
        launcRover: function () {
            axios.get(`/api/mission/LaunchRover?X=${this.newRover.x}&Y=${this.newRover.y}&Direction=${this.newRover.direction}`)
                .then(response => {
                    this.errors = {};
                    this.rovers.push({
                        x: response.data.x,
                        y: response.data.y,
                        id: response.data.id,
                        direction: response.data.directionChar,
                        commands: this.newRover.commands,
                        selectedCommand: this.newRover.selectedCommand
                    });

                    this.$toastr.Add({
                        name: "Mission Control",
                        msg: `Rover has been successfully deployed`, // Toast Message
                        type: "success", // Toast type,
                        position: "toast-bottom-right", // Toast Position.
                    });
                }).catch((error) => {
                    if (error.response.data !== undefined) {
                        this.errors = error.response.data;
                    }
                })
                .then(() => {  });
            
        },
        areaRovers: function (x, y) {
            return this.rovers.filter(r => r.x == x && r.y == y);
        },
        getTitle: function (c) {
            switch (c) {
                case "M":
                    return "Move forward";
                case "L":
                    return "Turn left";
                case "R":
                    return "Turn right";
            }
        },
        countRovers: function (x, y) {
            return this.rovers.filter(r => r.x == x && r.y == y).length;
        },
        getDirection(direction) {
            
            switch (direction) {
                case "N":
                    return "rv-arrow-up2";
                case "E":
                    return "rv-arrow-right2";
                case "S":
                    return "rv-arrow-down2";
                case "W":
                    return "rv-arrow-left2";
                default:
                    return "";

            }
        },
        translateDirection: function (id) {
            //N, S, E, W
            switch (id) {
                case 0: return "N";
                case 1: return "S";
                case 2: return "E";
                case 3: return "W";
                default: return "";
            }
        },
        move: function (rover, command) {
            
            //call api 
            axios.get(`/api/mission/move?roverId=${rover.id}&command=${command}`)
                .then(response => {

                    rover.x = response.data.x;
                    rover.y = response.data.y;
                    rover.direction = this.translateDirection(response.data.direction);
                    rover.selectedCommand = command;

                }).catch((error) => {
                    
                    const message = error.response.data != undefined ? error.response.data : "Oops! An error occured";
                    this.$toastr.Add({
                        name: "Mission Control", 
                        msg: message, // Toast Message
                        type: "error", // Toast type,
                        position: "toast-bottom-right", // Toast Position.
                    });
                })
                .then(() => {});
        }
    }
})