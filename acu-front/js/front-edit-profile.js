window.onload = function() {
      var user_id = localStorage.getItem("user_id");
      console.log(user_id);
      //JSON 檔案網址
      let url = `https://localhost:7105/api/User/F_All?user_id=${user_id}`;
      let data = [];
      // step 1 - 取得資料
      (function getData() {
        axios
          .get(url).then(function (response) {
            // 檢查
            console.log(response.data);
            // 將取得資料帶入空陣列data中
            data = response.data;
            console.log(response.data[0].user_account);
            console.log(response.data[0].user_gender);
            var user = document.getElementById("user");
            var name = document.getElementById("name");
            var sex = document.getElementById("sex");
            var age = document.getElementById("age");
            user.value = response.data[0].user_account;
            name.value = response.data[0].user_name;
            sex.value = response.data[0].user_gender;
            age.value = response.data[0].user_age;
          })
          .catch((error) => {
            console.log(error);
            alert("error:錯誤");
          });
      })();
    }


function nextt() {
            var user_id = localStorage.getItem("user_id");
            console.log(user_id);

            var name = document.getElementById("name").value;
            var sex = document.getElementById("sex").value;
            var age = document.getElementById("age").value;

            const formData = new FormData();
            // 添加文本字段
            formData.append('user_id', `${user_id}`);
            formData.append('user_name', name);
            formData.append('user_gender', sex);
            formData.append('user_age', age);

            axios.put('https://localhost:7105/api/User/F_Put', formData ,{
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(response => {
                console.log('Response:', response);
                // window.location.href = "back-news.html";
                  location.reload();
                alert("修改成功");
            }).catch(error => {
                console.error('Error:', error);
            });
}

