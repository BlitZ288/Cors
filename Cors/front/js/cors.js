
function brokenRequst () {
  const user = {name:"Feduy", Age:25};

  fetch(
    'https://localhost:7228/Home/PutUser',
    {
      method: 'PUT',
      headers: { 'Content-Type': 'application/json' },  
      body:JSON.stringify(user),        
    }
  ).then(resp => resp.text()).then(console.log)
}

function simpleRequest () {

    fetch(
        'https://localhost:7228/Home/GetUser',
        {
          method: 'GET',                 
        }
      ).then(resp => resp.text()).then(console.log)
}
function defaultRequest () {
  const user = {name:"Feduy", Age:25};

  fetch(
      'https://localhost:7228/Home/PutUser',
      {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },  
        body:JSON.stringify(user) 
      }
    ).then(resp => resp.text()).then(console.log)
}
function cookieRequest () {
  const user = {name:"Feduy", Age:25};

  fetch(
      'https://localhost:7228/Home/AddUser',
      {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },  
        body:JSON.stringify(user),
        credentials: 'include' /// include, *same-origin, omit
      }
    ).then(resp => resp.text()).then(console.log)
}