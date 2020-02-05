# pineapple
## experimental wiki system, backed by a git-based persistence adapter

## Motivation

Hosting a web-accessible wiki has been done exceptionally well by tools such as
[gollum][gl], presenting a very useful and feature-rich wrapper over locally
hosted git repositories.

With a very slim target feature set of creating/viewing spaces (git repositories)
and viewing/editing the contained pages (markdown files) within, this project is
a **case study** to learn new architectural concepts and the new .NET Core
tooling.

The base architecture is very strongly inspired by the Hexagonal Architecture,
in particular the .NET Core implementation in Ivan Paulovich's
[clean-architecture-manga][cam].

[gl]: https://github.com/gollum/gollum
[cam]: https://github.com/ivanpaulovich/clean-architecture-manga
