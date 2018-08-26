# CleanArchitecture_WinForm
sample code for CleanArchitecture with WinForm

下記の記事・ソースをもとに作成した、WinForm版のDDD実装サンプルです
- https://github.com/nrslib/CleanArchitectureSample
- https://nrslib.com/clean-architecture/

## 主な変更点
WinFormへの移植にあたり、下記実装を変更してます
- DIにはSimpleInjectorを利用
- UseCase.Coreを別プロジェクトに分割
