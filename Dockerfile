FROM mono:3.10-onbuild
CMD [ "mono",  "./DockerTest.exe" ]
EXPOSE 8880