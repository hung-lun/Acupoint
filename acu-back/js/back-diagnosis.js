var logout1 = document.getElementById("logout");
logout1.addEventListener("click", logout);
    function logout() {
        if (confirm('確認要登出嗎？') == true) {
            window.location.href = "../acu-front/login.html";
            localStorage.clear();
        } else {

        }
    }
    

    //JSON 檔案網址
  const url = "https://localhost:7105/api/Eye_question/GetQuestion";
  let data = [];
  fetch(url) //判斷api有沒有資料
    .then((response) => {
      if (response.ok) {
        //如果api有資料就執行以下程式碼顯示資料

        // step 1 - 取得資料
        (function getData() {
          axios.get(url).then(function (response) {
            // 檢查
            console.log(response.data);
            // 將取得資料帶入空陣列data中
            data = response.data;
            const eightdata = data.slice(0,8);
            const fourdata = data.slice(8,12);
            const threedata = data.slice(12,15);
            console.log(eightdata);
            data = eightdata;
            data1 = fourdata;
            data2 = threedata;
            title(data);
            title1(data1);
            title2(data2);
          });
        })();

        function title(arr) {
          // 抓取欄位
          const p_title = document.querySelector(".table_content");
          let str = "";
          // 將資料存入
          arr.forEach(function (data) {
            str += `
                    <tr>
                        <td class="Q-title">○　<input id="edit_question${data.eye_question_id}" type="text" value="${data.eye_question_content}"><input id="save${data.eye_question_id}" class="save mouse" type="button" value="儲存變更"></td>
                    </tr>
            `;
            // <input id="delete${data.eye_question_id}" class="delete mouse" type="button" value="刪除"></input>
          });
          p_title.innerHTML = str;
          arr.forEach(function (data) {
          var aas = document.getElementById("save" + `${data.eye_question_id}`)
        console.log(aas);
        var edit_question = document.getElementById("edit_question" + `${data.eye_question_id}`);
      function aa(e) {
            const formData = new FormData();
            // 添加文本字段
            formData.append('eye_question_id', `${data.eye_question_id}`);
            formData.append('eye_question_content', edit_question.value);

            axios.put('https://localhost:7105/api/Eye_question/PutEye_Question/'+`${data.eye_question_id}`+'/'+edit_question.value, {
                headers: {
                    'Content-Type': 'text/plain'
                }
            }).then(response => {
                console.log('Response:', response);
                // window.location.href = "back-news.html";
                  location.reload();
                alert("編輯成功");
            }).catch(error => {
                console.error('Error:', error);
            });
        }
        aas.addEventListener('click', aa);
      });
    }

        function title1(arr) {
          // 抓取欄位
          const p_title1 = document.querySelector(".table_content1");
          let str1 = "";
          // 將資料存入
          arr.forEach(function (data) {
            str1 += `
                    <tr>
                        <td class="Q-title">○　<input id="edit_question${data.eye_question_id}" type="text" value="${data.eye_question_content}"><input id="save${data.eye_question_id}" class="save mouse" type="button" value="儲存變更"></td>
                    </tr>
            `;
            // <input id="delete${data.eye_question_id}" class="delete mouse" type="button" value="刪除"></input>
          });
          p_title1.innerHTML = str1;

          arr.forEach(function (data) {
            var aas = document.getElementById("save" + `${data.eye_question_id}`)
          console.log(aas);
          var edit_question = document.getElementById("edit_question" + `${data.eye_question_id}`);
        function aa(e) {
              const formData = new FormData();
              // 添加文本字段
              formData.append('eye_question_id', `${data.eye_question_id}`);
              formData.append('eye_question_content', edit_question.value);
  
              axios.put('https://localhost:7105/api/Eye_question/PutEye_Question/'+`${data.eye_question_id}`+'/'+edit_question.value, {
                  headers: {
                      'Content-Type': 'text/plain'
                  }
              }).then(response => {
                  console.log('Response:', response);
                  // window.location.href = "back-news.html";
                    location.reload();
                  alert("編輯成功");
              }).catch(error => {
                  console.error('Error:', error);
              });
          }
          aas.addEventListener('click', aa);
        });
          }

          
          function title2(arr) {
          // 抓取欄位
          const p_title2 = document.querySelector(".table_content2");
          let str2 = "";
          // 將資料存入
          arr.forEach(function (data) {
            str2 += `
                    <tr>
                        <td class="Q-title">○　<input id="edit_question${data.eye_question_id}" type="text" value="${data.eye_question_content}"><input id="save${data.eye_question_id}" class="save mouse" type="button" value="儲存變更"></td>
                    </tr>
            `;
            // <input id="delete${data.eye_question_id}" class="delete mouse" type="button" value="刪除"></input>
          });
          p_title2.innerHTML = str2;

          arr.forEach(function (data) {
            var aas = document.getElementById("save" + `${data.eye_question_id}`)
          console.log(aas);
          var edit_question = document.getElementById("edit_question" + `${data.eye_question_id}`);
        function aa(e) {
              const formData = new FormData();
              // 添加文本字段
              formData.append('eye_question_id', `${data.eye_question_id}`);
              formData.append('eye_question_content', edit_question.value);
  
              axios.put('https://localhost:7105/api/Eye_question/PutEye_Question/'+`${data.eye_question_id}`+'/'+edit_question.value, {
                  headers: {
                      'Content-Type': 'text/plain'
                  }
              }).then(response => {
                  console.log('Response:', response);
                  // window.location.href = "back-news.html";
                    location.reload();
                  alert("修改成功");
              }).catch(error => {
                  console.error('Error:', error);
                  alert("error:錯誤");
              });
          }
          aas.addEventListener('click', aa);
        });
        }
      
      
        

    }
    

      });