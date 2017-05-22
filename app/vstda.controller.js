(function () {
  'use strict';

  angular
    .module('toDoList')
    .controller('ToDoController', ToDoController);

  ToDoController.$inject = ['vstdaFactory'];

  /* @ngInject */
  function ToDoController(vstdaFactory) {
    var vm = this;

    // Empty Variables 
    vm.toDotext = "";
    vm.toDoArr = [];
    vm.toDoObj = {};
    vm.sort = 'value';
    vm.title = 'vstdaFactory';
    vm.date = new Date();

    // On Click Event - Triggers Post Request and Then Pushes data to Front
    vm.addNew = function (toDoObj) {
      toDoObj.CreationDate = vm.date;
      vstdaFactory
        .keepTask(toDoObj)
        // Logs Either Success Object or Error Message
        .then(function (response) {
          console.log(response);
          pushTodo(response.data);
        }, function (error) {
          console.log(error);
        })
    }
    //Push To List
    function pushTodo(todo) {
      vm.toDoArr.push({
        text: vm.toDoObj.text,
        priority: vm.toDoObj.priority
      });
    }
  }
})();
