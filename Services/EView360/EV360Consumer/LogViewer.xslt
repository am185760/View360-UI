<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="Log">
		<html>
			<boby>
				<table width="100%" border="2">
					<xsl:for-each select="Task">
						<tr>
							<Td>
								<xsl:value-of select="Log/Task/RefNo"/>
							</Td>
							<Td>
								<xsl:value-of select="Log/Task/Name"/>
							</Td>
							<Td colspan="7">
								<xsl:value-of select="Log/Task/Activity"/>
							</Td>
						</tr>
						<xsl:for-each select="Activity">
							<tr>
								<Td colspan="2"></Td>
								<td>
									<xsl:value-of select="./Time"/>
								</td>
								<td>
									<xsl:value-of select="./TraceLevel"/>
								</td>
								<td>
									<xsl:value-of select="./FunctionName"/>
								</td>
								<td>
									<xsl:value-of select="./Msg"/>
								</td>
								<td>
									<xsl:value-of select="./StackTrace"/>
								</td>
							</tr>
						</xsl:for-each>
					</xsl:for-each>
				</table>
			</boby>
		</html>
	</xsl:template>
</xsl:stylesheet>