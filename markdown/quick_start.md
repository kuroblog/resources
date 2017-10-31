# Markdown Quick Start *ver 1.0*

|Ver|User|Date|Remark
|:-|-|-|:-
|1.0|kuro|2017-10-29|Created

##### *References*

* [Markdown Language Spec](http://blog.leanote.com/post/freewalk/Markdown-%E8%AF%AD%E6%B3%95%E6%89%8B%E5%86%8C)
* [Learn Markdown in 60 Seconds](http://commonmark.org/help/)
* [GitHub](https://github.com)
  * [Awesome Markdown](https://github.com/BubuAnabelas/awesome-markdown)
  * [Flavored Markdown Spec](https://github.github.com/gfm/)
* [The text/markdown Media Type (RFC7763)](https://tools.ietf.org/html/rfc7763)
* [Guidance on Markdown (RFC7764)](https://tools.ietf.org/html/rfc7764)

### Contents

---

* [Title 标题](#title-标题)
* [Separator 分隔线](#separator-分隔线)
* [Font 字体](#font-字体)
  * [Bold 加粗](#bold-加粗)
  * [Italic 斜体](#italic-斜体)
  * [Strikethrough 删除线](#strikethrough-删除线)
* [Hyperlink 超链接](#hyperlink-超链接)
* [Picture 图片](#picture-图片)
* [Anchor 锚点](#anchor-锚点)
* [List 列表](#list-列表)
  * [Ordered List 有序列表](#ordered-list-有序列表)
  * [Unordered List 无序列表](#unordered-list-无序列表)
* [Table 表格](#table-表格)
* [Paragraph 段落](#paragraph-段落)
* [Blockquote 块引用](#blockquote-块引用)
* [Code Segment 代码段](#code-Segment-代码段)
* [Escape character 转义字符](#escape-character-转义字符)

***

### Title 标题

***

表达式为 `# 标题内容` ，总共有6个级别，分别用1~6个 `#` 标记作为前缀来表示

***example***

```markdown
# title 1
## title 2
### title 3
#### title 4
##### title 5
###### title 6
```

***output***

<h1>title 1</h1>
<h2>title 2</h2>
<h3>title 3</h3>
<h4>title 4</h4>
<h5>title 5</h5>
<h6>title 6</h6>

**PS: Markdown兼容HTML标签，此处的输出效果使用了HTML的标签，和使用Markdown标记的效果是一样的**

#### Separator 分隔线

表达式是 `***` 、 `---` 或者 `___` ，在单行内使用连续的3个或以上的 `*` 、 `-` 或者 `_` 标记，行内不能有其它字符或标记

***example***

```markdown
***
---
___
```

***output***

***
---
___

***

### Font 字体

***

* #### Bold 加粗

  表达式是 `**需要加粗显示的内容**`

  ***example***

  ```markdown
  这里是**加粗显示**的
  ```

  ***output***

  这里是**加粗显示**的

* #### Italic 斜体

  表达式是 `*需要倾斜显示的内容*` 或者 ` _需要倾斜显示的内容_ ` ，以 `_` 标记来显示， `_` 标记的两边是需要保留空格的

  ***example***

  ```markdown
  这里是*斜体显示*的，这是还是 _斜体显示_ 的
  ```

  ***output***

  这里是*斜体显示*的，这是还是 _斜体显示_ 的

* #### Strikethrough 删除线

  Markdown不支持删除线，但是可以通过使用HTML的 `del` 标记来实现，表达式是 `<del>需要添加删除线的内容</del>`

  ***example***

  ```markdown
  这是需要显示<del>删除线</del>的
  ```

  ***output***

  这是需要显示<del>删除线</del>的

### Hyperlink 超链接

***

超链接的使用方式有多种

1. 直接使用 `<超链接的URL>`
1. `[超链接的名称](超链接的URL "可选的描述")`
1. 先使用 `[超链接的代号]: 超链接的URL "可选的描述"` 或者 `[超链接的代号]: 超链接的URL (可选的描述)` 来定义超链接，然后再使用 `[超链接的名称][超链接的代号]` 来引用

***example***

```markdown
<https://www.baidu.com/>  
[baidu.com](https://www.baidu.com/ "link to baidu.com")  
[baidu.com][baidu-1]  
[百度][baidu-2]

[baidu-1]: https://www.baidu.com/ "链接到百度"
[baidu-2]: https://www.baidu.com/ (link to baidu.com)
```

***output***

<https://www.baidu.com/>  
[baidu.com](https://www.baidu.com/ "link to baidu.com")  
[baidu.com][baidu-1]  
[百度][baidu-2]

[baidu-1]: https://www.baidu.com/ "链接到百度"
[baidu-2]: https://www.baidu.com/ (link to baidu.com)

**PS: 这里显示换行是因为在行尾添加了2个连续的空格，其功能是强制换行**

### Picture 图片

***

图片的使用方式有多种

1. `![图片的名称](图片的URL "可选的描述")`
1. 先使用 `[图片的代号]: 图片的URL "可选的描述"` 或者 `[图片的代号]: 图片的URL (可选的描述)` 来定义图片，然后再使用 `![图片的名称][图片的代号]` 来引用

***example***

```markdown
![图片MD](https://raw.githubusercontent.com/kuroblog/resources/master/asserts/images/md_24.png "字符MD的图片")  
![图片MD1][md1]  
![图片MD2][md2]

[md1]: https://raw.githubusercontent.com/kuroblog/resources/master/asserts/images/md_48.png "48x48的图片"
[md2]: https://raw.githubusercontent.com/kuroblog/resources/master/asserts/images/md_48.png (128x128的图片)
```

***output***

![图片MD](https://raw.githubusercontent.com/kuroblog/resources/master/asserts/images/md_24.png "字符MD的图片")  
![图片MD1][md1]  
![图片MD2][md2]

[md1]: https://raw.githubusercontent.com/kuroblog/resources/master/asserts/images/md_48.png "48x48的图片"
[md2]: https://raw.githubusercontent.com/kuroblog/resources/master/asserts/images/md_128.png (128x128的图片)

**PS: 这里的显示效果同样是使用了在行尾使用了2个连续的空格**

### Anchor 锚点

***

可以用中文字符来使用锚点，使用方式有多种，**注意锚点的定义必须确保唯一性，不能重复**

|定义|引用|说明
|:-|:-|:-
|`### 标题名称`|`[标题名称或描述](#标题名称)`|
|`### 大写的标题名称`|`[标题名称或描述](#小写的标题名称)`|大写字母需要全部转换成小写字母
|`### 标题名称 序号`|`[标题名称或描述](#标题名称-序号)`|标题名称中存在的空格以 `-` 标记来替代，连续的多个空格均已1个 `-` 标记来替代
|`### 1. 标题名称`|`[标题名称或描述](#1-标题名称)`|序号后以 `-` 标记来连接标题名称


***example***

```markdown
#### title1
[title 1](#title1)

#### Title2
[title 2](#title2)

#### title 33
[title 3](#title-33)

#### 标题4
[标题 4](#标题4)

#### 标题 5

#### 5.1. 子标题 1
#### 5.2. Sub Title 2

[标题 5](#标题-5)  
[标题 5.1](#51-子标题-1)  
[标题 5.2](#52-sub-title-2)
```

***output***

#### title1
[title 1](#title1)

#### Title2
[title 2](#title2)

#### title 33
[title 3](#title-33)

#### 标题4
[标题 4](#标题4)

#### 标题 5

#### 5.1. 子标题 1
#### 5.2. Sub Title 2

[标题 5](#标题-5)  
[标题 5.1](#51-子标题-1)  
[标题 5.2](#52-sub-title-2)

**PS:**

* 上面定义的title 33，是因为之前的演示是已经使用了title 3，如果出现同名的锚点定义，会跳转到第1次出现的位置
* GitHub不支持HTML格式的锚点链接，此处使用的是符合GitHub规则的方法
* 非英文的锚点字符，在单击跳转时，在浏览器的URL中会按照规则进行Encode和Decode

### List 列表

***

* #### Ordered List 有序列表

  表达式是 `1. 列表项名称` ，以数字开始，列表项的数字序号可以是非连续的

  ***example***

  ```markdown
  1. 列表项 1
  2. 列表项 2
  3. 列表项 3

  1. 列表项 a
  999. 列表项 b
  1. 列表项 c
  ```

  ***output***

  1. 列表项 1
  2. 列表项 2
  3. 列表项 3

  1. 列表项 a
  999. 列表项 b
  1. 列表项 c

* #### Unordered List 无序列表

  无序列表的表达式有多种

  1. `* 列表项`
  1. `+ 列表项`
  1. `- 列表项`

  ***example***

  ```markdown
  * 列表项 1
  * 列表项 2
    + 列表项 a
      + 列表项 b
    - 列表项 I
  - 列表项 II
  ```

  ***output***

  * 列表项 1
  * 列表项 2
    + 列表项 a
      + 列表项 b
    - 列表项 I
  - 列表项 II

### Table 表格

***

表达式如下，对齐不是必须的

`|列头1|列头2|列头3`  
`|-|:-|-:`  
`|行1列1|行1列2|行1列3`

***example***

```markdown
|col 1|col 2|col 3
|-|:-|-:
|tom|16|99
|jan|11|100
```

***output***

|col 1|col 2|col 3
|-|:-|-:
|tom|16|99
|jan|11|100

### Paragraph 段落

***

在Markdown中段落以空行开始，并以空行结束，连续的行即使是换行了也会被解析成在一个段落内，区别只是会在之间加1个空格

***example***

```markdown
这里是段落1
这里是段落2，虽然回车了但是没有换行，只是在2个段落之间添加了1个空格

这里是段落3，这里换新行了是因为段落以空行开始，并以空行结束  
这里是段落4，这里也换新行了，但不是一个新的段落，只是段落3在行尾使用了2个连续的空格来强制换行了
```

***output***

这里是段落1
这里是段落2，虽然回车了但是没有换行，只是在2个段落之间添加了1个空格

这里是段落3，这里换新行了是因为段落以空行开始，并以空行结束  
这里是段落4，这里也换新行了，但不是一个新的段落，只是段落3在行尾使用了2个连续的空格来强制换行了

### Blockquote 块引用

***

表达式是 `> 需引用显示的内容`，首行首字符以1个 `>` 标记开始，可以连续多行或者嵌套使用

***example***

```markdown
> 这里是一个引用的内容，为测试效果打印一些信息：在战争模式(War Mode)中，玩家可以选择盟军和轴心国军队两个阵营，互相对抗完成战略目标。比如E3展演示中，进攻方的玩家通过完成占领据点、修复桥梁、炸毁弹药还有护送装甲车等一系列任务来赢得胜利。不过根据视频来看，这个模式的载具是无法操作的，只能使用载具上的武器。

> 块1  
> 块2
> > 块2.1  
> > 块2.2
> > > 块2.2.1  
> > > 块2.2.2
> >
> > 块2.3
> 
> 块3  
> 块4
```

***output***

> 这里是一个引用的内容，为测试效果打印一些信息：在战争模式(War Mode)中，玩家可以选择盟军和轴心国军队两个阵营，互相对抗完成战略目标。比如E3展演示中，进攻方的玩家通过完成占领据点、修复桥梁、炸毁弹药还有护送装甲车等一系列任务来赢得胜利。不过根据视频来看，这个模式的载具是无法操作的，只能使用载具上的武器。

> 块1  
> 块2
> > 块2.1  
> > 块2.2
> > > 块2.2.1  
> > > 块2.2.2
> >
> > 块2.3
> 
> 块3  
> 块4

### Code Segment 代码段

***

分为行代码段和块代码段，参照example

1. 行代码段以 \` 标记开始和结束，比如 \`这里是需要显示的代码段\`
2. 块代码段以单独一行的 ``` 标记开始和结束，开始部分的标记后面可以带上代码语言的描述，比如 \`\`\`csharp

***example***

```markdown
`html` `csharp` `<del>123</del>`

```csharp
static void main(string[] args){
  Console.WriteLine(nameof());
}
```
```

***output***

`html` `csharp` `<del>123</del>`

```csharp
static void main(string[] args){
  Console.WriteLine(nameof());
}
```

### Escape character 转义字符

***

总共有12个转义字符，如下

1. `\\` 反斜杠
1. ``\'`` 反引号，此处为针对代码段要显示反引号的情况
1. `\*` 星号
1. `\_` 下划线
1. `\{\}` 大括号
1. `\[\]` 中括号
1. `\(\)` 小括号
1. `\#` 井号
1. `\+` 加号
1. `\-` 减号
1. `\.` 英文句号
1. `\!` 感叹号




